using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class ModifyProductTitleRequest
   {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductTitleId { get; set; }
        public int ManufactureId { get; set; }
        public int BrandId { get; set; }
        public int ProductModelId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
