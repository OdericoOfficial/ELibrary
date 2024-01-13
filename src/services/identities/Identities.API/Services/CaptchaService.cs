using ModuleDistributor.Grpc;
using ModuleDistributor.Logging;
using Microsoft.Extensions.Options;
using ModuleDistributor.Dapr;
using Dapr.Client;
using System.Net.Mail;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Identities.Shared;
using Identities.Protos;

namespace Identities.API.Services
{
    [GrpcService]
    internal class CaptchaService : Captcha.CaptchaBase, ILoggerProxy<CaptchaService>
    {
        private readonly DaprOptions _daprOptions;
        private readonly DaprClient _daprClient;
        private readonly SmtpClient _smtpClient;

        public ILogger<CaptchaService> Logger { get; }
        ILogger ILoggerProxy.Logger 
            => Logger;

        public CaptchaService(SmtpClient smtpClient, DaprClient daprClient, 
            IOptions<DaprOptions> daprOptions, ILogger<CaptchaService> logger)
        {
            _daprClient = daprClient;
            _smtpClient = smtpClient;
            _daprOptions = daprOptions.Value;
            Logger = logger;
        }

        [AllowAnonymous, ExLogging]
        public override async Task<Empty> SendEmail(EmailCaptchRequest request, ServerCallContext context)
        {
            var status = await _daprClient.GetStateAsync<EmailStatus>(_daprOptions.StateStore, request.Receiver);
            if (status is not null && (DateTime.UtcNow - status.TimeStamp).TotalSeconds < 30)
                throw new ArgumentException("Too many request.");

            var captcha = new Random().Next(10000, 99999);

            var message = new MailMessage();
            message.From = new MailAddress(_smtpClient.Host!);
            message.To.Add(new MailAddress(request.Receiver));
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = "验证码";
            message.Body = $"{captcha}";

            await _smtpClient.SendMailAsync(message);

            status = new EmailStatus
            {
                Captcha = captcha,
                TimeStamp = DateTime.UtcNow,
                Receiver = request.Receiver
            };
            await _daprClient.SaveStateAsync(_daprOptions.StateStore, request.Receiver, status);

            return IdentitiesAPIModule.Empty;
        }
    }
}
