using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Orders
{
   public class CreateOrderRequest
    {
        public Guid BasketId { get; set; }
        public int Id { get; set; }
        public string IdentityToken { get; set; }
        public string UserName { get; set; }
    }
}
