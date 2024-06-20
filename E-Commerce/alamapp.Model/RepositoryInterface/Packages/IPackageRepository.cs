using alamapp.Infrastructure.Domain;
using alamapp.Model.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface.Packages
{
   public interface IPackageRepository:IRepository<Package,int>
    {

    }
}
