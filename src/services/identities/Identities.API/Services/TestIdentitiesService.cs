using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using ModuleDistributor.Grpc;
using Identities.Protos;

namespace Identities.Shared
{
    [GrpcService]
    internal class TestIdentitiesService : TestIdentities.TestIdentitiesBase
    {
        private readonly ILogger<TestIdentitiesService> _logger;

        public TestIdentitiesService(ILogger<TestIdentitiesService> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public override Task<HelloWorldResponse> HelloWorld(Empty request, ServerCallContext context)
        {

            return Task.FromResult(new HelloWorldResponse
            {
                Message = "HelloWorld"
            });
        }

        [AllowAnonymous]
        public override async Task HelloWorldServerStream(Empty request, IServerStreamWriter<HelloWorldResponse> responseStream, ServerCallContext context)
        {
            for (int i = 0; i < 10; i++)
                await responseStream.WriteAsync(new HelloWorldResponse
                {
                    Message = "HelloWorld"
                });
        }

        [AllowAnonymous]
        public override async Task<Empty> HelloWorldClientStream(IAsyncStreamReader<HelloWorldRequest> requestStream, ServerCallContext context)
        {
            await foreach (var item in requestStream.ReadAllAsync())
                _logger.LogInformation(item.Message);

            return new Empty();
        }

        [AllowAnonymous]
        public override async Task HelloWorldBinaryStream(IAsyncStreamReader<HelloWorldRequest> requestStream, IServerStreamWriter<HelloWorldResponse> responseStream, ServerCallContext context)
        {
            await foreach (var item in requestStream.ReadAllAsync())    
                await responseStream.WriteAsync(new HelloWorldResponse { Message = item.Message });
        }
    }
}
