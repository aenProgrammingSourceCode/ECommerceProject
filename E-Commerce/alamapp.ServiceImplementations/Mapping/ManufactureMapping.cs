using alamapp.Model.Products;
using alamapp.ServiceImplementations.ViewModel.Brands;
using alamapp.ServiceImplementations.ViewModel.Manufactures;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class ManufactureMapping
    {
       public static IEnumerable<ManufactureView> ConvertToManufactureViews(this IEnumerable<Manufacture> manufactures)
       {
           return Mapper.Map<IEnumerable<Manufacture>, IEnumerable<ManufactureView>>(manufactures);
       }
    }
}
