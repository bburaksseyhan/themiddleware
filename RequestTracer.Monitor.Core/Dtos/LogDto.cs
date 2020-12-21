using System;

namespace RequestTracer.Core.Dtos
{
    public class LogDto
    {
        public Guid Id { get { return Guid.NewGuid(); } }

        public DateTime Date { get { return DateTime.UtcNow; } }

        public string ApplicationName { get; set; }

        public string Environment { get; set; }

        public LogDetail LogDetail { get; set; }
    }
}
