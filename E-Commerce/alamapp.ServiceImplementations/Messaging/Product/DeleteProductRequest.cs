using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class DeleteProductRequest
    {
        public DeleteProductRequest()
        {
           DeleteProductId = new List<DeleteProductIdRequest>();
        }
        public IList<DeleteProductIdRequest> DeleteProductId { get; set; }
        
    }
}
