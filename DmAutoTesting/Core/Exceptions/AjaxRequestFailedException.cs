using System;
using Core.Browsers.Ajax;

namespace Core.Exceptions
{
    public class AjaxRequestFailedException : Exception
    {
        public AjaxRequestFailedException(AjaxRequest request)
            : base($"Ajax request on url {request.Url} ended with an error {request.HttpStatusCode}")
        {
        }
    }
}