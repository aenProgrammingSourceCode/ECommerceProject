using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Category
{
   public class DeleteCategoryRequest
    {
       public DeleteCategoryRequest()
       {
           DeleteRequestId = new List<DeleteCategoryRequestId>();
       }
        public IList<DeleteCategoryRequestId> DeleteRequestId { get; set; }
    }
}
