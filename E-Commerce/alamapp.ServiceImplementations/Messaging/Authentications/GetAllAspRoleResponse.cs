using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Authentications
{
   public class GetAllAspRoleResponse
    {
        public IEnumerable<AspRoleView> AspRoles { get; set; }
    }
}
