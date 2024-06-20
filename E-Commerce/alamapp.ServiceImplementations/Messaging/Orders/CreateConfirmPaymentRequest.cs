using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Orders
{
   public class CreateConfirmPaymentRequest
    {
        public int Id { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
