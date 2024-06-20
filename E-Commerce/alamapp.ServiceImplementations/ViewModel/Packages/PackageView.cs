using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Packages
{
   public class PackageView
    {
       public PackageView()
       {
           PackageItems = new List<PackageItemView>();
       }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }

        public IEnumerable<PackageItemView> PackageItems { get; set; }
    }
}
