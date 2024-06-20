using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Orders
{
   public class OrderView
    {
       public OrderView()
       {
           OrderItem = new List<OrderItemView>();
       }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string IdentityToken { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderItemView> OrderItem { get; set; }
    }
}
