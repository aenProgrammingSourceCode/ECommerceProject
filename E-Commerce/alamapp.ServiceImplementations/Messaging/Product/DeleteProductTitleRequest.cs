using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class DeleteProductTitleRequest
    {
        public DeleteProductTitleRequest()
        {
            RemoveToProduct = new List<int>();
        }
        public IList<int> RemoveToProduct { get; set; }
    }
}
