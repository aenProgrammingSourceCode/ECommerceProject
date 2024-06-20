using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Manufactures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIApplication.Controllers
{
    public class ManufactureController : ApiController
    {
        private IManufactureService _manufactureService;
        public ManufactureController(IManufactureService manufactureService)
        {
            _manufactureService = manufactureService;
        }
        public HttpResponseMessage GetAllManufacture()
        {
            GetAllManufactureResponse response =_manufactureService.GetAllManufactures();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
    }
}
