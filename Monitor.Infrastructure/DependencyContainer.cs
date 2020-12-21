using System;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestTracer.Core.Commands;

namespace RequestTracer.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services, IConfiguration configuration)
        {
            #region IoC layer
            services.AddMediatR(typeof(LogCommand));

            //mass transit configuration
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.UseHealthCheck(provider);
                    config.Host(new Uri(configuration.GetSection("RabbitMqSettings:host").Value), "/",
                    h =>
                    {
                        h.Heartbeat(TimeSpan.FromSeconds(30));
                        h.Username(configuration.GetSection("RabbitMqSettings:username").Value);
                        h.Password(configuration.GetSection("RabbitMqSettings:password").Value);
                    });

                }));
            });

            services.AddMassTransitHostedService();

            #endregion

            #region Database Layer
            #endregion

            #region Application Layer
            #endregion
        }
    }
}
