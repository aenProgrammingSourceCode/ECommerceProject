using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Baskets
{
   public class BasketItemView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSizeName { get; set; }
        public int Qty { get; set; }
        public string ProductPrice { get; set; }
        public decimal LineTotal { get; set; }
        public Guid ProductImageId { get; set; }
    }
}
