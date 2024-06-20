using alamapp.Model.RepositoryInterface;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.ServiceImplementations.ViewModel.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class IProductAttributeMapping
    {
       public static RefinementGroup ConvertToRefinementGroup(this IEnumerable<IProductAttribute> productAttribute,
           RefinementGroupings refinementGroupings)
       {
           RefinementGroup refinementGroup = new RefinementGroup()
           {
                GroupId=(int)refinementGroupings,
                Name=refinementGroupings.ToString()
           };

           refinementGroup.Refinements = Mapper.Map<IEnumerable<IProductAttribute>, IEnumerable<Refinement>>(productAttribute);
           return refinementGroup;
       }
    }
}
