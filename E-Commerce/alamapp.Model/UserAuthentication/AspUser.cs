using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.UserAuthentication
{
   public class AspUser:EntityBase<string>, IAggregateRoot
    {
        public string UserEmail { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }

       
    }
}
