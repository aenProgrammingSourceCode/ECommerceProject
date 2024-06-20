using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Baskets
{
  public  class CreateProductBasketRequest
    {
        public CreateProductBasketRequest()
        {
            productToAdd = new List<int>();
        }

        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public IList<int> productToAdd { get; set; }
    }
}
