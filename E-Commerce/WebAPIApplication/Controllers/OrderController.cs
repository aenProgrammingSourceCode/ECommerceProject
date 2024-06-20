using alamapp.Infrastructure.CookieStorage;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WebAPIApplication.Controllers
{
    public class OrderController : BaseApiController
    {
        private IOrderService _orderService;
        private ICookieStorageService _cookieStorageService;
        public string UserId { get; set; }
        public OrderController(IOrderService orderService, ICookieStorageService cookieStorageService)
               : base(cookieStorageService)
        {
            _orderService = orderService;
            _cookieStorageService = cookieStorageService;
        }


        [HttpPost]
        public HttpResponseMessage PlaceOrder(CreateOrderRequest orderRequest)
        {
            CreateOrderRequest request = new CreateOrderRequest();
            request.IdentityToken = orderRequest.IdentityToken;
            request.BasketId = base.GetBasketId();
            request.UserName = orderRequest.UserName;
            CreateOrderResponse response = _orderService.CreateOrder(request); 
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Order.Id);

            _cookieStorageService.Save("BasketId","BasketId", DateTime.Now);
             _cookieStorageService.Save("NumberOfItem","NumberOfItem", DateTime.Now);
            _cookieStorageService.Save("BasketTotal","BasketTotal", DateTime.Now);

            return httpResponse;
         
        }

        [HttpGet]
        public HttpResponseMessage GetOrderByIdentityToken(string identityToken)
        {
            GetOrdersByTokenRequest orderRequest = new GetOrdersByTokenRequest() { IdentityToken = identityToken };
            GetOrdersByTokenResponse response = _orderService.GetOrderByToken(orderRequest);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage GetOrderItemByIdentityToken(string identityToken)
        {
            GetOrderItemByTokenRequest request = new GetOrderItemByTokenRequest() { IdentityToken=identityToken };
            GetOrderItemByTokenResponse response = _orderService.GetOrderItemByToken(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpPost]
        public void CreatePayment()
        {
            CreatePaymentRequest pRequest = new CreatePaymentRequest();
            pRequest.MobileBankName = "Bkash";
            pRequest.MobileBankNo = "01789109271";
            pRequest.isFinished = 1;
            pRequest.Amount = 9000;
            _orderService.CreatePayment(pRequest);
        }

        [HttpGet]
        public HttpResponseMessage GetAllPayment(CreatePaymentRequest request)
        {
            GetAllPaymentResponse response = _orderService.GetAllPayment(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK,response.Payments);
            return httpResponse;
        }

        [HttpPost]
        public void ConfirmePayment(int id)
        {
            CreateConfirmPaymentRequest pRequest = new CreateConfirmPaymentRequest() { Id=id};
            _orderService.ConfirmPayment(pRequest);
        }
    }
}
