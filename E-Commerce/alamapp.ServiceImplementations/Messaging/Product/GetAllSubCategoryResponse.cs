using alamapp.Model.Products;
using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class GetAllSubCategoryResponse
    {
        public IEnumerable<SubCategoryView> SubCategories { get; set; }
    }
}
