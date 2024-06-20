using alamapp.Model.Categories;
using alamapp.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class CategoryMapping
    {
       public static CategoryView ConvertToCategoryView(this Category category)
       {
           return Mapper.Map<Category, CategoryView>(category);
       }

       public static IEnumerable<CategoryView> ConvertToCategoryViews(this IEnumerable<Category> categories)
       {
           return Mapper.Map<IEnumerable<Category>,IEnumerable<CategoryView>>(categories);
       }
    }
}
