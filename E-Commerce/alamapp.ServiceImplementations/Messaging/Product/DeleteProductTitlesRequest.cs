using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class DeleteProductTitlesRequest
    {
        public DeleteProductTitlesRequest()
        {
           DeleteProductTitleId = new List<DeleteProductIdRequest>();
        }
        public IList<DeleteProductIdRequest> DeleteProductTitleId { get; set; }
    }
}
