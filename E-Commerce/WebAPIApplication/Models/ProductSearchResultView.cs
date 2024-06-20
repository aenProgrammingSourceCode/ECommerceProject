using alamapp.ServiceImplementations.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class ProductSearchResultView
    {
        public ProductSearchResultView()
        {
            RefinementGroups = new List<RefinementGroup>();
        }

        public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }

        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }

        public int NumberOfTitlesFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }

        public IEnumerable<ProductTitleView> Products { get; set; }
    }
}