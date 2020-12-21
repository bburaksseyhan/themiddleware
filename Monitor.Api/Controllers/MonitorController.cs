using System;
using System.Threading.Tasks;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Monitor.Api.Commands;

namespace Monitor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MonitorController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // POST: api/Monitor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginCommand command)
        {
            await _mediator.Send(new LoginCommand()
            {
                 Id = command.Id,
                  Name = command.Name,
                   Desc = command.Desc 
            });

            return Ok(true);
        }
    }
}
