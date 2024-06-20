using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.RepositoryInterface.Auth;
using alamapp.Model.UserAuthentication;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.ServiceImplementations.Mapping;

namespace alamapp.ServiceImplementations.Implementation
{
   public class AspAuthenticationService:IAspAuthenticationService
    {
       private readonly IAspRoleRepository _aspRoleRepository;
       private readonly IAspUserRoleRepository _aspUserRoleRepository;
       private readonly IUnitOfWork _uow;
       public AspAuthenticationService(IAspRoleRepository aspRoleRepository,
           IAspUserRoleRepository aspUserRoleRepository,
           IUnitOfWork uow)
       {
           _aspRoleRepository = aspRoleRepository;
           _aspUserRoleRepository = aspUserRoleRepository;
           _uow = uow;
       }
       public GetAllAspRoleResponse GetAllAspRole()
       {
           GetAllAspRoleResponse response = new GetAllAspRoleResponse();
           IEnumerable<AspRole> aspRoles = _aspRoleRepository.FindAll();
           response.AspRoles = aspRoles.ConvertToAspRoleViews();
           return response;
       }

       public GetAspRoleResponse GetRole(GetAspRoleRequest request)
       {  
           GetAspRoleResponse respons=new GetAspRoleResponse();
           AspRole aspRole = _aspRoleRepository.FindBy(request.RoleId);
           respons.AspRole = aspRole.ConvertToAspRoleView();
           return respons;
       }


       public GetAspUserRoleResponse GetUserRole(GetAspUserRoleRequest request)
       {
           GetAspUserRoleResponse response = new GetAspUserRoleResponse();
           AspUserRole aspUserRole = _aspUserRoleRepository.FindBy(request.UserId);
           response.AspUserRole = aspUserRole.ConvertToAspUserRoleView();
           return response;
       }


       public void ModifyRoleByUser(ModifyAspUserRoleRequest request)
       {
           AspRole aspRole = _aspRoleRepository.FindBy(request.RoleId);
           AspUserRole aspUserRole = _aspUserRoleRepository.FindBy(request.UserId);
           aspUserRole.Role = aspRole;
           _aspUserRoleRepository.Save(aspUserRole);
           _uow.Commit();
       }
    }
}
