using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Categories
{
   public class Category:EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public Guid ImageId { get; set; }
        public string Description { get; set; }
       protected override void Validate()
        { 
        }
    }
}
