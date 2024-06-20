using alamapp.Model.UserAuthentication;
using alamapp.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class AspAuthMapping
    {
        public static IEnumerable<AspRoleView> ConvertToAspRoleViews(this IEnumerable<AspRole> aspRoles)
        {
            return Mapper.Map<IEnumerable<AspRole>, IEnumerable<AspRoleView>>(aspRoles);
        }
        public static AspRoleView ConvertToAspRoleView(this AspRole aspRole)
        {
            return Mapper.Map<AspRole, AspRoleView>(aspRole);
        }
        public static AspUserRoleView ConvertToAspUserRoleView(this AspUserRole aspUserRole)
        {
            return Mapper.Map<AspUserRole, AspUserRoleView>(aspUserRole);
        }
    }
}
