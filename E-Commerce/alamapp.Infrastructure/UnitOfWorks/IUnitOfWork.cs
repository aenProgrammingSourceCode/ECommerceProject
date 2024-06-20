using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void RegisterAmanded(IAggregateRoot entity, IUnitOfWorkRepository unitofworkRepository);
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofworkRepository);
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofworkRepository);
        void Commit();

    }
}
