using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using RequestTracer.Core.Commands;

namespace RequestTracer.Core.Handlers
{
    public class LogCommandHandler : IRequestHandler<LogCommand, bool>
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        private ISendEndpoint _sendEndpoint;

        public LogCommandHandler(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;

            var environment = Environment.GetEnvironmentVariables()["ASPNETCORE_ENVIRONMENT"].ToString();

           _sendEndpoint = _bus.GetSendEndpoint(
                new Uri($"{_configuration.GetSection("RabbitMqSettings:server").Value}/{configuration.GetSection("ApplicationName").Value}-{environment}-Logs"))
                               .GetAwaiter()
                               .GetResult();
        }

        public async Task<bool> Handle(LogCommand request, CancellationToken cancellationToken)
        {
            await _sendEndpoint.Send(request);

            return true;
        }
    }
}
