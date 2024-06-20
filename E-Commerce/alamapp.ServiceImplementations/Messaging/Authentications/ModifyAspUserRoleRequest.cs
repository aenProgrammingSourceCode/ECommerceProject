using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Authentications
{
   public class ModifyAspUserRoleRequest
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
