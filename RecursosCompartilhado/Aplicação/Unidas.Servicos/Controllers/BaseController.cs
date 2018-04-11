using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unidas.Servicos.Metadata;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Unidas.Servicos.Controllers
{
    public class BaseController : Controller
    {
  
        protected async Task<ResponseBase> CreateOkResponse(object value)
        {
            return await CreateResponse("OK", "OK", value);
        }

        protected async Task<ResponseBase> CreateOkResponse(string message)
        {
            return await CreateResponse("OK", message);
        }

        protected async Task<ResponseBase> CreateBadRequestResponse(string message)
        {
            return await CreateResponse("INVALID", message);
        }

        protected async Task<ResponseBase> CreateBadRequestResponse(string[] message)
        {
            return await CreateResponse("INVALID", "INVALID", message);
        }

        protected async Task<ResponseBase> CreateCreatedResponse(string message)
        {
            return await CreateResponse("CREATED", message);
        }

        protected async Task<ResponseBase> CreateCreatedResponse(string message, object value)
        {
            return await CreateResponse("CREATED", message, value);
        }

        protected async Task<ResponseBase> CreateCreatedResponse(object value)
        {
            return await CreateResponse("CREATED", "recurso criado", value);
        }

        async Task<ResponseBase> CreateResponse(string status, string message, object data = null)
        {
            var result = string.Empty;

            return await Task.FromResult(new ResponseBase { Status = status, Message = message, Data = data });
        }
    }
}
