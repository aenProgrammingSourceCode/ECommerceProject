using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Category
{
    public class CreateCategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ImageId { get; set; }
        public string Description { get; set; }

    }
}