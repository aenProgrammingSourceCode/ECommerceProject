using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Baskets
{
   public class DeleteBasketRequest
    {
        public Guid BasketId { get; set; }
        public DeleteBasketRequest()
        {
            DeleteProducts = new List<DeleteProductFromBasketItemRequest>();
        }
        public IList<DeleteProductFromBasketItemRequest> DeleteProducts { get; set; }
    }
}
