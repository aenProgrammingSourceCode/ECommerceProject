using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class CreateProductImageRequest
    {
        public int Id { get; set; }
        public int ProductTitleId { get; set; }
        public Guid SampleImage { get; set; }
    }
}
