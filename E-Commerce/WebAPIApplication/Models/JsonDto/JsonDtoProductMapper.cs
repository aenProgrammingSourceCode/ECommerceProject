using alamapp.ServiceImplementations.Messaging.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models.JsonDto
{
    public static class JsonDtoProductMapper
    {
        public static IList<DeleteProductIdRequest> ConvertToProductjsonRequests(this JsonProductRequests jsonRequests)
        {
           return jsonRequests.ProductTitles.ConvertToProductRequests();
        }
        public static IList<DeleteProductIdRequest> ConvertToProductRequests(this JsonProductRequest[] jsonRequests)
        {
            IList<DeleteProductIdRequest> productList = new List<DeleteProductIdRequest>();
            int i = 0;
            for (i = 0; i <jsonRequests.Length; i++)
            {
                productList.Add(jsonRequests[i].ConvertToProductRequest());
            }
            return productList;
        }
        public static DeleteProductIdRequest ConvertToProductRequest(this JsonProductRequest jsonRequest)
        {
            return new DeleteProductIdRequest
            {
                ProductTitleId = jsonRequest.ProductTitleId
            };
        }
    }
}