using alamapp.ServiceImplementations.ViewModel.Manufactures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Manufactures
{
   public class GetAllManufactureResponse
    {
        public IEnumerable<ManufactureView> Manufactures { get; set; }
    }
}
