using alamapp.Model.Packages;
using alamapp.ServiceImplementations.ViewModel.Packages;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class PackageItemMapping
    {
       public static PackageItemView ConvertToPackageItemView(this PackageItem packageItem)
       {
           return Mapper.Map<PackageItem, PackageItemView>(packageItem);
       }
    }
}
