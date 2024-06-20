using alamapp.ServiceImplementations.ViewModel.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Brands
{
   public class GetAllBrandResponse
    {
        public IEnumerable<BrandView> Brands { get; set; }
    }
}
