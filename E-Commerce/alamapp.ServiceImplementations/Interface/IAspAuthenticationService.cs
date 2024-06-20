using alamapp.ServiceImplementations.Messaging.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface IAspAuthenticationService
    {
       GetAllAspRoleResponse GetAllAspRole();
       GetAspRoleResponse GetRole(GetAspRoleRequest request);
       GetAspUserRoleResponse GetUserRole(GetAspUserRoleRequest request);
       void ModifyRoleByUser(ModifyAspUserRoleRequest request);
    }
}
