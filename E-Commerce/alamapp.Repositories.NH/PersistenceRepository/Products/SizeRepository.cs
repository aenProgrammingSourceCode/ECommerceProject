﻿using alamapp.Infrastructure.Domain;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Products
{
   public class SizeRepository:Repository<Size,int>, ISizeRepository
    {
       public SizeRepository(IUnitOfWork uow):base(uow)
       {

       }
    }
}
