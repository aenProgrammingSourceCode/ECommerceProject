using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Orders
{
   public class PaymentTermView
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string CreateDate { get; set; }
        public string MobileBankName { get; set; }
        public bool IsFinished { get; set; }
        public string SentAmountDate { get; set; }
        public int MobileBankNo { get; set; }
        public string TransactionNo { get; set; }
        public int PaymentId { get; set; }
    }
}
