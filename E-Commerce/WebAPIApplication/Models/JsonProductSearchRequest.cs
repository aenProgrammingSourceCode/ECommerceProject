using alamapp.ServiceImplementations.Messaging.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class JsonProductSearchRequest
    {
        public int CategoryId { get; set; }
        public int[] ColorIds { get; set; }
        public int[] SizeIds { get; set; }
        public int[] BrandIds { get; set; }
        public ProductsSortBy SortBy { get; set; }
        public IEnumerable<JsonRefinementGroup> RefinementGroups { get; set; }
        public int Index { get; set; }
    }
}