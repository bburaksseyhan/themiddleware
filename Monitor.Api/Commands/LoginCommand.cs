using System;
using MassTransit;
using MediatR;

namespace Monitor.Api.Commands
{
    public class LoginCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
    }

}
