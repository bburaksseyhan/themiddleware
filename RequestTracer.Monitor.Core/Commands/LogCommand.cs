using MediatR;
using RequestTracer.Core.Dtos;

namespace RequestTracer.Core.Commands
{
    public class LogCommand : IRequest<bool>
    {
        public LogDto LogDtos { get; set; }
    }
}
