using System.Collections.Generic;
using System.Net;

namespace Application.Base
{
    public abstract class BaseResponse
    {
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public bool State { get; set; }
    }

    public class Response<T> : BaseResponse, IResponse<T> where T : class
    {
        public T Data { get; set; }
        public Response()
        {

        }
        public Response(string message, HttpStatusCode code = HttpStatusCode.OK, bool state = true, T data = null)
        {
            Message = message;
            Code = code;
            State = state;
            Data = data;
        }
    }
}