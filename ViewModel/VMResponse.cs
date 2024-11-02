using System.Net;

namespace ViewModel
{
    public class VMResponse<TEntity>
    {
        public HttpStatusCode statusCode {  get; set; }
        public string? message { get; set; }
        public TEntity? data { get; set; }

        public VMResponse()
        {
            statusCode = HttpStatusCode.InternalServerError;
            message = string.Empty;
            data = default(TEntity);
        }
    }
}
