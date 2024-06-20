using alamapp.ServiceImplementations.Messaging.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class ProductSearchCriteria
    {
        public int BrandId { get; set; }
        public int ManufactureId { get; set; }
        public int ProductModelId { get; set; }
        public int CategoryId { get; set; }
        public ProductsSortBy SortBy { get; set; }
    }
}