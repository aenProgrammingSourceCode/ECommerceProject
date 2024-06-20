
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.RepositoryInterface.Auth;
using alamapp.Model.UserAuthentication;
using alamapp.Repositories.NH.PersistenceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.NhRepository.PersistenceRepository.Auth
{
   public class AspUserRoleRepository:Repository<AspUserRole,string>,IAspUserRoleRepository
    {
       public AspUserRoleRepository(IUnitOfWork uow)
           : base(uow)
       {

       }
    }
}
