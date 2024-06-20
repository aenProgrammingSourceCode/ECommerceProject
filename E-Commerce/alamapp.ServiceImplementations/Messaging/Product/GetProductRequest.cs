using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class GetProductRequest
    {
        public string CriteriaName { get; set; }
        public int Id { get; set; }
        public int ColorId { get; set; }
    }
}
