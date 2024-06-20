using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Manufactures;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class ManufactureService:IManufactureService
    {
       private IManufactureRepository _manufactureRepository;
       public ManufactureService(IManufactureRepository manufactureRepository)
       {
           _manufactureRepository = manufactureRepository;
       }
        public GetAllManufactureResponse GetAllManufactures()
        {
            GetAllManufactureResponse response = new GetAllManufactureResponse();
            IEnumerable<Manufacture> manufactures = _manufactureRepository.FindAll();
            response.Manufactures = manufactures.ConvertToManufactureViews();
            return response;
        }
    }
}
