using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Baskets
{
   public class ModifyProductBasketRequest
    {
        public Guid BasketId { get; set; }
        public ModifyProductBasketRequest()
        {
            ProductToAdd = new List<int>();
            UpdateItemQty = new List<UpdateProductQtyRequest>();
        }
        public IList<int> ProductToAdd { get; set; }
        public IList<UpdateProductQtyRequest> UpdateItemQty { get; set; }
    }
}
