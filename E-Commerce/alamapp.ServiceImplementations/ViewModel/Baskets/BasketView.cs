using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Baskets
{
   public class BasketView
    {
       public BasketView()
       {
           BasketItemViews = new List<BasketItemView>();
       }
       public Guid Id { get; set; }
       public string BasketTotal { get; set; }
       public int NumberOfItem { get; set; }
       public IEnumerable<BasketItemView> BasketItemViews { get; set; }
    }
}
