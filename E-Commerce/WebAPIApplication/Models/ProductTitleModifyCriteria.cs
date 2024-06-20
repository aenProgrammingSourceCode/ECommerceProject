using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class ProductTitleModifyCriteria
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductTitleId { get; set; }
        public int ManufactureId { get; set; }
        public int BrandId { get; set; }
        public int ProductModelId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}