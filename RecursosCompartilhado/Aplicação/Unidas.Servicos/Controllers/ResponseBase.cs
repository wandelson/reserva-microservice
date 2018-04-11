using System;
namespace Unidas.Servicos.Controllers
{
    public class ResponseBase
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
