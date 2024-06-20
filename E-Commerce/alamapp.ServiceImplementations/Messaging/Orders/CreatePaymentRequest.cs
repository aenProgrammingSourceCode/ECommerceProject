using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Orders
{
   public class CreatePaymentRequest
    {
        public int Id { get; set; }
        public string IdentityToken { get; set; }
        public string MobileBankNo { get; set; }
        public string MobileBankName { get; set; }
        public int OrderId { get; set; }
        public string SentAmountDate { get; set; }
        public decimal  Amount { get; set; }
        public string TransactionId { get; set; }
        public int isFinished { get; set; }
    }
}
