using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public HttpResponseMessage CreateCustomer(CreateCustomerRequest request)
        {
           CreateCustomerResponse response= _customerService.CreateCustomer(request);
           HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Customer.Name);
           return httpResponse;
        }
        [HttpPost]
        public void CreateDeliveryAddress(CreateDeliveryAddressRequest request)
        {
            _customerService.CreateDeliveryAddress(request);
        }

        [HttpGet]
        public HttpResponseMessage GetCustomerByIdentity(GetCustomerByIdentityTokenRequest request)
        {
           GetCustomerByIdentityTokenResponse response = _customerService.GetByIdentityToken(request);
           HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
           return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage GetAllDistricts()
        {
            GetAllDistrictResponse response = _customerService.GetAllDistricts();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage GetAllPoliceStations()
        {
            GetAllPoliceStationResponse response = _customerService.GetAllPoliceStations();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
    }
}
