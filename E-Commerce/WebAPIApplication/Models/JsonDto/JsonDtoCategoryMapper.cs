using alamapp.ServiceImplementations.Messaging.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models.JsonDto
{
    public static class JsonDtoCategoryMapper
    {
        public static IList<DeleteCategoryRequestId> ConvertToCategoryRequests(this JsonCategoryRequests requests)
        {
            return requests.Categories.ConvertToCategoryRequests();
        }
        public static IList<DeleteCategoryRequestId> ConvertToCategoryRequests(this JsonCategoryRequest[] requests)
        {
            IList<DeleteCategoryRequestId> categoryRequests = new List<DeleteCategoryRequestId>();
            int i = 0;
            for (i = 0; i < requests.Length; i++)
            {
                categoryRequests.Add(requests[i].ConvertToCategoryRequest());
            }
            return categoryRequests;
        }
        public static DeleteCategoryRequestId ConvertToCategoryRequest(this JsonCategoryRequest request)
        {
            return new DeleteCategoryRequestId
            {
                NewCategoryId = request.CategoryId
            };
        }
    }
}