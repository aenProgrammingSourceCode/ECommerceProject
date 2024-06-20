using alamapp.ServiceImplementations.ViewModel;
using alamapp.ServiceImplementations.ViewModel.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.ProductModels
{
   public class GetAllProductModelResponse
    {
        public IEnumerable<ProductModelView> ProductModels { get; set; }
    }
}
