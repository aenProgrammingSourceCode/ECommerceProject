using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.Domain
{
   public class ValueObjectIsInvalid:Exception
    {
       public ValueObjectIsInvalid(string message):base(message)
       {

       }
    }
}
