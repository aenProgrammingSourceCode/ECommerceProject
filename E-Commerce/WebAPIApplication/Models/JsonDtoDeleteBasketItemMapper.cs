using alamapp.ServiceImplementations.Messaging.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public static class JsonDtoDeleteBasketItemMapper
    {

        public static IList<DeleteProductFromBasketItemRequest> ConvertToBasketProducts(this JsonDeleteProductFromBasketRequests jsonRequests)
        {
            return jsonRequests.Products.ConvertToProducts();
        }

        public static IList<DeleteProductFromBasketItemRequest> ConvertToProducts(this JsonDeleteProductFromBasketRequest[] Jsonrequests)
        {
            IList<DeleteProductFromBasketItemRequest> productList=new List<DeleteProductFromBasketItemRequest>();
            int i = 0;
            for (i = 0; i < Jsonrequests.Length; i++)
            {
                productList.Add(Jsonrequests[i].ConvertToProduct());
            }
            return productList;
        }

        public static DeleteProductFromBasketItemRequest ConvertToProduct(this JsonDeleteProductFromBasketRequest request)
        {
            return new DeleteProductFromBasketItemRequest
            {
                ProductId = request.ProductId
            };
        }
    }
}