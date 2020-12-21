namespace RequestTracer.Core.Dtos
{
    public class LogDetail
    {
        public string Host { get; set; }

        public string Method { get; set; }

        public string Protocol { get; set; }

        public string Schema { get; set; }

        public string Path { get; set; }

        public string QueryStringParameter { get; set; }

        public int StatusCode { get; set; }

        public string ContentType { get; set; }

        public long? ContentLength { get; set; }

        public string ExecutionTime { get; set; }
    }
}

