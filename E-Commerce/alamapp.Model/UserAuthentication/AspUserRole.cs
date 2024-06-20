using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.UserAuthentication
{
   public class AspUserRole:EntityBase<string>,IAggregateRoot
    {
        public AspRole Role { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
