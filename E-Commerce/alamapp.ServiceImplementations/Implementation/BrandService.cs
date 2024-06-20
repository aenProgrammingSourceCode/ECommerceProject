using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Brands;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class BrandService:IBrandService
    {
        private IBrandRepository _brandRepository;

       public BrandService(IBrandRepository brandRepository)
       {
           _brandRepository = brandRepository;
       }

       public GetAllBrandResponse GetAllBrands()
       {
           GetAllBrandResponse response=new GetAllBrandResponse();
           IEnumerable<Brand> brands = _brandRepository.FindAll();
           response.Brands = brands.ConvertToBrandViews();
           return response;
       }
    }

}
