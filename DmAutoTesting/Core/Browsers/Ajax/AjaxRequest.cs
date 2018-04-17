using System.Net;

namespace Core.Browsers.Ajax
{
    public class AjaxRequest
    {
        public string Type { get; set; }
        public bool Async { get; set; }
        public string Url { get; set; }
        public AjaxRequestState State { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string PostData { get; set; }
    }
}