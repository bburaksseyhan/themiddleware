using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Monitor.Api.Commands;

namespace Monitor.Api.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand,bool>
    {
       //private IBus _bus;
       // private ISendEndpoint _sendEndPoint;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler( IConfiguration configuration)
        {
            _configuration = configuration;
           // _sendEndPoint = _bus.GetSendEndpoint(new Uri($"{_configuration.GetSection("RabbitMqSettings:server").Value}/Logs")).GetAwaiter().GetResult();
        }

        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
              // await _sendEndPoint.Send(request);

            }
            catch (Exception ex)
            {

            }

            return true;
        }
    }
}
