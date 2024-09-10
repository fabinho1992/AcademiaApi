namespace Academia.WebApi.ErrosMiddleware
{
    public class ErroResponse
    {
        public ErroResponse(string traceId, List<ErroDetalhes> erros)
        {
            TraceId = Guid.NewGuid().ToString();
            Erros = new List<ErroDetalhes>();
        }

        public ErroResponse(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Erros = new List<ErroDetalhes>();
            AddError(logref, message);
        }

        public string TraceId { get; private set; }
        public List<ErroDetalhes> Erros { get; private set; }

        public class ErroDetalhes
        {
            public ErroDetalhes(string logref, string message)
            {
                Logref = logref;
                Message = message;
            }

            public string Logref { get; private set; }
            public string Message { get; private set; }
        }

        public void AddError(string logref, string message)
        {
            Erros.Add(new ErroDetalhes(logref, message));
        }
    }

    
}
