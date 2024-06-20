using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface;
using alamapp.ServiceImplementations.ViewModel.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class ProductTitleMapping
    {
      public static IEnumerable<ProductTitleView> ConvertToProductTitleViews(this IEnumerable<ProductTitle> product)
       {
           return Mapper.Map<IEnumerable<ProductTitle>, IEnumerable<ProductTitleView>>(product);
       }

      public static ProductTitleView ConvertToProductTitleView(this ProductTitle product)
      {
          return Mapper.Map<ProductTitle, ProductTitleView>(product);
      }
    }
}
