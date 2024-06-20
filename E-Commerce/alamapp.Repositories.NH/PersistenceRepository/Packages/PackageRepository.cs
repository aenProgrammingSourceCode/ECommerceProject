using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Packages;
using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Packages
{
   public class PackageRepository:Repository<Package,int>,IPackageRepository
    {
       public PackageRepository(IUnitOfWork uow):base(uow)
       {

       }
    }
}
