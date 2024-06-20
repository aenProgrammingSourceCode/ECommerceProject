using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class CreateProductTitleRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufactureId { get; set; }
        public int BrandId { get; set; }
        public int ProductModelId { get; set; }
        public string MadeIn { get; set; }
        public int ColorId { get; set; }
        public string FabricName { get; set; }
        public int SubCategoryId { get; set; }
        public string Description { get; set; }
        public int SizeId { get; set; }
        public Guid ImageId { get; set; }
    }
}
