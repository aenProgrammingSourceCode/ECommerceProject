using alamapp.Model.Products;
using alamapp.ServiceImplementations.ViewModel.ProductModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class ProductModelMapping
    {
       public static IEnumerable<ProductModelView> ConvertToProductModelViews(this IEnumerable<ProductModel> productModel)
       {
           return Mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductModelView>>(productModel);
       }
    }
}
