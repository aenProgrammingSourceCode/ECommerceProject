using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIApplication.Controllers
{
    public class BrandController : ApiController
    {
        private IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public HttpResponseMessage GetAllBrands()
        {
            GetAllBrandResponse response = _brandService.GetAllBrands();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
    }
}
