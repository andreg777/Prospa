using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prospa.Core;
using Prospa.Core.Interface;
using Prospa.Model;

namespace Prospa.Web.Controller
{
    public class ChequeApiController : ApiController
    {
        private readonly IChequeService _chequeService;
        public ChequeApiController(IChequeService chequeService)
        {
            _chequeService = chequeService;
        }

        [HttpPost]
        public HttpResponseMessage ConvertNumberToWords(ChequeModel chequeModel)
        {            
            var model = _chequeService.ConvertNumbersToWords(chequeModel);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}
