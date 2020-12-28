using System;
using System.Net;

namespace WebApplication1
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            Code = HttpStatusCode.InternalServerError;
            Success = false;
            Data = default(T);
            Message = "";
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
