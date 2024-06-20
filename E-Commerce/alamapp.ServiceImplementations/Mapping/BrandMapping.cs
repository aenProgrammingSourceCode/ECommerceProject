using alamapp.Model.Products;
using alamapp.ServiceImplementations.ViewModel.Brands;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class BrandMapping
    {
        public static IEnumerable<BrandView> ConvertToBrandViews(this IEnumerable<Brand> brand)
        {
            return Mapper.Map<IEnumerable<Brand>,IEnumerable<BrandView>>(brand);
        }
    }
}
