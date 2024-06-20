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
   public static class PackageMapping
    {
       public static PackageView ConvertToPackageView(this Package package)
       {
           return Mapper.Map<Package, PackageView>(package);
       }
    }
}
