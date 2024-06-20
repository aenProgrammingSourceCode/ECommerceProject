using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Categories
{
   public class CategoryBusinessRule
    {
       public static readonly BusinessRule CategoryNameRequired
           = new BusinessRule("Category Name", "A Category must have a name");
       public static readonly BusinessRule CategoryDescritpionRequired
           = new BusinessRule("Category Description", "A Category must have a description");
    }
}
