using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel
{
   public class CategoryView
    {
       public CategoryView()
       {
           CategoryImageView = new List<CategoryImageView>();
       }
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ImageId { get; set; }
        public string Description { get; set; }
        public IEnumerable<CategoryImageView> CategoryImageView { get; set; }
    }

}
