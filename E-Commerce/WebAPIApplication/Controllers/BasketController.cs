using alamapp.Infrastructure.CookieStorage;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class BasketController : BaseApiController
    {
        public IBasketService _basketService;
        private ICookieStorageService _cookieStorageService;
        public BasketController(IBasketService basketService,ICookieStorageService cookieStorageService):base(cookieStorageService)
        {
            _basketService = basketService;
            _cookieStorageService = cookieStorageService;
        }


        [HttpPost]
        public HttpResponseMessage AddProductItemToBasket(int ProductId)
        {
            Guid basketId = base.GetBasketId();
            bool createNewBasket = basketId == Guid.Empty;
           
            BasketSummaryView basketSummaryView=new BasketSummaryView();
            if (createNewBasket == false)
            {
                ModifyProductBasketRequest request = new ModifyProductBasketRequest();
                request.ProductToAdd.Add(ProductId);
                request.BasketId = basketId;

                try
                {
                   ModifyProductBasketResponse response=_basketService.ModifyProductBasket(request);
                   basketSummaryView = response.Basket.ConvertToSummary();
                   SaveBasketSummary(basketSummaryView.BasketTotal, basketSummaryView.NumberOfItems);
                }
                catch (Exception)
                {

                    createNewBasket = true;
                }

            }
            if (createNewBasket)
            {
                CreateProductBasketRequest request = new CreateProductBasketRequest();
                request.productToAdd.Add(ProductId);

                CreateProductBasketResponse response = _basketService.AddProductToBasket(request);
                basketSummaryView=response.Basket.ConvertToSummary();
                SaveBasketIdToCookie(response.Basket.Id);
                SaveBasketSummary(basketSummaryView.BasketTotal, basketSummaryView.NumberOfItems);
            }

            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, basketSummaryView);
            return httpResponse;
        }

        [HttpPost]
        public HttpResponseMessage UpdateBasketItem(JsonUpdateProductQtyRequests jsonRequest)
        {
            ModifyProductBasketRequest request = new ModifyProductBasketRequest();
            request.BasketId = base.GetBasketId();
            request.UpdateItemQty = jsonRequest.ConvertToProductRequestsfromJson();
            ModifyProductBasketResponse response = _basketService.ModifyProductBasket(request);
            BasketSummaryView basketSummary = new BasketSummaryView();
            basketSummary = response.Basket.ConvertToSummary();
            SaveBasketSummary(basketSummary.BasketTotal, basketSummary.NumberOfItems);

            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, basketSummary);
            return httpResponse;
        }

         [HttpPost]
        public HttpResponseMessage DeleteBasketItem(JsonDeleteProductFromBasketRequests jsonRequest)
        {
            DeleteBasketRequest request = new DeleteBasketRequest();
            request.BasketId = base.GetBasketId();

            request.DeleteProducts = jsonRequest.ConvertToBasketProducts();
            DeleteBasketResponse response = _basketService.DeleteBasket(request);
            BasketSummaryView basketSummary = new BasketSummaryView();
            basketSummary = response.Basket.ConvertToSummary();
            SaveBasketSummary(basketSummary.BasketTotal, basketSummary.NumberOfItems);

            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, basketSummary);
            return httpResponse;
        }


        public void AddPackageToBasket(int packageId)
        {
            CreateBasketRequest request = new CreateBasketRequest() { PackageId = packageId };
            CreateBasketResponse response = _basketService.AddPackageToBasket(request);
            SaveBasketIdToCookie(response.Basket.Id);
        }
        public HttpResponseMessage GetBasketItemDetails()
        {
            Guid basketId = base.GetBasketId();
            GetBasketRequest request = new GetBasketRequest() { BasketId=basketId };
            GetBasketResponse response = _basketService.GetBasket(request);

            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Basket.BasketItemViews.Distinct());
            return httpResponse;
        }

        //public HttpResponseMessage GetBasketDetails()
        //{
        //    Guid basketId = base.GetBasketId();
        //    GetBasketRequest request = new GetBasketRequest() { BasketId = basketId };
        //    GetBasketResponse response = _basketService.GetBasket(request);

        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
        //    return httpResponse;
        //}

        //public HttpResponseMessage GetBasketItemDetails()
        //{
        //    GetBasketItemRequest request = new GetBasketItemRequest() { BasketItemId = 36 };
        //    GetBasketItemResponse response = _basketService.GetBasketItem(request);

        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
        //    return httpResponse;
        //}

        public void SaveBasketIdToCookie(Guid basketId)
        {
            _cookieStorageService.Save(CookieDataKey.BasketId.ToString(), basketId.ToString(), DateTime.Now.AddDays(1));
        }

        public void SaveBasketSummary(string basketTotal, int numberOfItem)
        {
            _cookieStorageService.Save(CookieDataKey.BasketTotal.ToString(), basketTotal.ToString(), DateTime.Now.AddDays(1));
            _cookieStorageService.Save(CookieDataKey.NumberOfItem.ToString(), numberOfItem.ToString(), DateTime.Now.AddDays(1));
        }

        [HttpPost]
        public void Delete(int id)
        {
            _basketService.DeleteBasketItemById(id);
        }
    }
}
