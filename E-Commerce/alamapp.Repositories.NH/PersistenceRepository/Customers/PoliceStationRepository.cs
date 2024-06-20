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
    public class PoliceStationRepository:Repository<PoliceStation,int>,IPoliceStationRepository
    {
        public PoliceStationRepository(IUnitOfWork uow)
           : base(uow)
       {

       }
    }
}
