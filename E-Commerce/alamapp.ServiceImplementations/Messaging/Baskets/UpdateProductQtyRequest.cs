using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Baskets
{
   public class UpdateProductQtyRequest
    {
        public int ProductId { get; set; }
        public int NewQty { get; set; }
    }
}
