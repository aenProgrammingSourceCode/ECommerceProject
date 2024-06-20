using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Customer
{
   public class GetAllPoliceStationResponse
    {
        public IEnumerable<PoliceStationView> PoliceStations { get; set; }
    }
}
