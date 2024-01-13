using Grpc.Core;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModuleDistributor.Grpc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ModuleDistributor.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Dapr.Client;
using ModuleDistributor.Dapr;
using Google.Protobuf.WellKnownTypes;
using Identities.Protos;
using Identities.Shared;

namespace Identities.API
{
    [GrpcService]
    internal class AuthenticationService : Authentication.AuthenticationBase, ILoggerProxy<AuthenticationService>
    {
        private readonly DaprOptions _daprOptions;
        private readonly DaprClient _daprClient;
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ILogger<AuthenticationService> Logger { get; }
        ILogger ILoggerProxy.Logger
            => Logger;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            DaprClient daprClient, IOptions<DaprOptions> daprOptions,
                IOptions<JwtTokenOptions> jwtTokenOptions, ILogger<AuthenticationService> logger)
        {
            _daprClient = daprClient;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenOptions = jwtTokenOptions.Value;
            _daprOptions = daprOptions.Value;
            Logger = logger;
        }

        [AllowAnonymous, ExLogging]
        public override async Task<SignInResponse> SignIn(SignInRequest request, ServerCallContext context)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                throw new ArgumentNullException("User is not exist.");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!result.Succeeded)
                throw new ArgumentException("Password not correct.");

            var token = new JwtSecurityToken(
                _jwtTokenOptions.Issuer,
                _jwtTokenOptions.Audience,
                await _userManager.GetClaimsAsync(user),
                DateTime.UtcNow,
                DateTime.UtcNow.AddYears(1),
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key)), 
                    SecurityAlgorithms.HmacSha256));

            return new SignInResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.UserName,
                UserId = user.Id
            };
        }

        [AllowAnonymous, ExLogging]
        public override async Task<Empty> Register(RegisterRequest request, ServerCallContext context)
        {
            await VerifyRegisterInfomation(request).ConfigureAwait(false);

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Eamil
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.Select(item => item.Description).Aggregate((str1, str2) => $"{str1}\n{str2}"));

            result = await _userManager.AddToRoleAsync(user, "User");
            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.Select(item => item.Description).Aggregate((str1, str2) => $"{str1}\n{str2}"));

            result = await _userManager.AddClaimsAsync(user,
                (await _userManager.GetRolesAsync(user))
                    .Select(item => new Claim(ClaimTypes.Role, item))
                    .Union(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                    }));
            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.Select(item => item.Description).Aggregate((str1, str2) => $"{str1}\n{str2}"));

            return IdentitiesAPIModule.Empty;
        }

        [AllowAnonymous, ExLogging]
        public override async Task<Empty> RegisterNoCaptcha(RegisterNoCaptchaRequest request, ServerCallContext context)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user is not null)
                throw new ArgumentNullException("UserName is already exist.");
            user = await _userManager.FindByEmailAsync(request.Eamil);
            if (user is not null)
                throw new ArgumentNullException("Eamil is already exist.");

            user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Eamil
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.Select(item => item.Description).Aggregate((str1, str2) => $"{str1}\n{str2}"));

            result = await _userManager.AddToRoleAsync(user, "User");
            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.Select(item => item.Description).Aggregate((str1, str2) => $"{str1}\n{str2}"));

            result = await _userManager.AddClaimsAsync(user,
                (await _userManager.GetRolesAsync(user))
                    .Select(item => new Claim(ClaimTypes.Role, item))
                    .Union(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                    }));
            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.Select(item => item.Description).Aggregate((str1, str2) => $"{str1}\n{str2}"));

            return IdentitiesAPIModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override Task<Empty> Check(Empty request, ServerCallContext context)
            => Task.FromResult(request);

        private async Task VerifyRegisterInfomation(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user is not null)
                throw new ArgumentNullException("UserName is already exist.");
            user = await _userManager.FindByEmailAsync(request.Eamil);
            if (user is not null)
                throw new ArgumentNullException("Eamil is already exist.");

            var status = await _daprClient.GetStateAsync<EmailStatus>(_daprOptions.StateStore, request.Eamil);
            if (status is null || (DateTime.UtcNow - status.TimeStamp).TotalMinutes > 3)
                throw new ArgumentException("Captcha timeout.");
            if (status.Captcha != request.Captcha)
                throw new ArgumentException("Captch not correct.");
        }
    }
}
