using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RequestTracer.Core.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LogMiddleware> _logger;

        public LogMiddleware(RequestDelegate next,
                             IMediator mediator,
                             IConfiguration configuration,
                             ILogger<LogMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(next));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(_configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                await _next(httpContext);
                stopwatch.Stop();

                await SendRequest(httpContext, stopwatch);
            }
            catch (Exception ex)
            {
                _logger.LogError($"LogMiddleware {ex}");

                if (httpContext.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started");
                    throw;
                }
            }
        }

        private async Task SendRequest(HttpContext httpContext,Stopwatch stopwatch)
        {
            var request = httpContext.Request;
            var response = httpContext.Response;
           
            await _mediator.Send(new Commands.LogCommand()
            {
                LogDtos = new Dtos.LogDto()
                {
                    ApplicationName = _configuration.GetSection("ApplicationName").Value,
                    Environment = Environment.GetEnvironmentVariables()["ASPNETCORE_ENVIRONMENT"].ToString(),
                    LogDetail = new Dtos.LogDetail()
                    {
                        Host = request.Host.HasValue == true ? request.Host.ToString() : string.Empty,
                        Method = request.Method,
                        Protocol = request.Protocol,
                        Schema = request.Scheme,
                        Path = request.Path,
                        QueryStringParameter = request.QueryString.HasValue ? request.QueryString.Value : string.Empty,
                        StatusCode = response.StatusCode,
                        ContentType = response.ContentType,
                        ContentLength = request.ContentLength,
                        ExecutionTime = $"Execution time of {stopwatch.ElapsedMilliseconds} ms"
                    }
                }
            });
        }
    }
}

