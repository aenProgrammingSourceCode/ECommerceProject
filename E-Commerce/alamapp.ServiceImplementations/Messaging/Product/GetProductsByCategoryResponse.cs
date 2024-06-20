using alamapp.ServiceImplementations.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class GetProductsByCategoryResponse
    {
        public int Id { get; set; }
        public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }

        public IEnumerable<ProductView> BaseProduct { get; set; }
        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }

        public int NumberOfTitlesFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }

        public IEnumerable<ProductTitleView> Products { get; set; }
        public IEnumerable<SizeView> Sizes { get; set; }
    }
}
