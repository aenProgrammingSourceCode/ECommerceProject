using alamapp.Model.Products;
using alamapp.ServiceImplementations.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class GetAllSizeResponse
    {
        public IEnumerable<SizeView> Sizes { get; set; }
    }
}
