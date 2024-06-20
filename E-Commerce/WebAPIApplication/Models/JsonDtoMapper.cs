using alamapp.ServiceImplementations.Messaging.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public static class JsonDtoMapper
    {
        public static IList<UpdateProductQtyRequest> ConvertToProductRequestsfromJson(this JsonUpdateProductQtyRequests jsonRequests)
        {
            return jsonRequests.Items.ConvertToProductRequests();
        }
        public static IList<UpdateProductQtyRequest> ConvertToProductRequests(this JsonUpdateProductQtyRequest[] jsonRequests)
        {
            IList<UpdateProductQtyRequest> productRequest = new List<UpdateProductQtyRequest>();

            int i=0;
            for (i = 0; i < jsonRequests.Length; i++)
            {
                productRequest.Add(jsonRequests[i].ConvertToProductRequest());
            }
            return productRequest;
        }
        public static UpdateProductQtyRequest ConvertToProductRequest(this JsonUpdateProductQtyRequest jsonRequest)
        {
            return new UpdateProductQtyRequest
            {
                ProductId = jsonRequest.ProductId,
                NewQty = jsonRequest.Qty
            };
        }
    }
}