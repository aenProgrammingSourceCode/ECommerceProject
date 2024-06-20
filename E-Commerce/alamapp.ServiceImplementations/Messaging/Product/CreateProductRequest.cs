using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class CreateProductRequest
    {
        public int ProductTitleId { get; set; }
        public int SizeId { get; set; }
    }
}
