namespace BlazorSignalR.Client.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }
        public T? Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetError()
        {
            if (!Error)
                return null;

            var codeStatus = HttpResponseMessage.StatusCode;
            switch (codeStatus)
            {
                case System.Net.HttpStatusCode.NotFound:
                    return "Not found Resource";
                case System.Net.HttpStatusCode.BadRequest:
                    return await HttpResponseMessage.Content.ReadAsStringAsync();
                case System.Net.HttpStatusCode.Unauthorized:
                    return "Before logging for to do this";
                case System.Net.HttpStatusCode.Forbidden:
                    return "No permission for to do this";
                default:
                    return "Unspected error";
            }

        }
    }
}
