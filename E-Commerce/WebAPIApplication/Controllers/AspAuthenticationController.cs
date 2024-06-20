using alamapp.Infrastructure.UnitOfWorks;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIApplication.Controllers
{
    public class AspAuthenticationController : ApiController
    {
        private readonly IAspAuthenticationService _aspAuthenticationService;
        private readonly IUnitOfWork _uow;
        public AspAuthenticationController(IAspAuthenticationService aspAuthenticationService, IUnitOfWork uow)
        {
            _aspAuthenticationService = aspAuthenticationService;
            _uow = uow;
        }
        public void ModifyRoleByUser(string UserId, ModifyAspUserRoleRequest request)
        {
            ModifyAspUserRoleRequest UrRequest = new ModifyAspUserRoleRequest() { UserId = UserId };
            UrRequest.RoleId = request.RoleId;
            _aspAuthenticationService.ModifyRoleByUser(UrRequest);
            _uow.Commit();
        }
    }
}
