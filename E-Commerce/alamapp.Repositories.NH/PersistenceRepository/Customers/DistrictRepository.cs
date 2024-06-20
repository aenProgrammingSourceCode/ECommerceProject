using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Customers;
using alamapp.Model.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Customers
{
   public class DistrictRepository:Repository<District,int>,IDistrictRepository
    {
       public DistrictRepository(IUnitOfWork uow)
           :base(uow)
	    {

	    }
    }
}
