using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIApplication.Controllers
{
    public class ProductModelController : ApiController
    {
        private IProductModelService _productModelService;
        public ProductModelController(IProductModelService productModelService)
        {
            _productModelService = productModelService;
        }
        public HttpResponseMessage GetAllProductModel()
        {
            GetAllProductModelResponse response=_productModelService.GetAllProductModel();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
    }
}
