using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Customer
{
   public class GetAllDistrictResponse
    {
        public IEnumerable<DistrictView> Districts { get; set; }
    }
}
