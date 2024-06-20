using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Orders
{
   public static class PaymentTermFactory
    {
       public static PaymentTerm CreatePaymentTermFor(string mobileBankNo, Payment payment,Order order, decimal amount, string mobileBankName, string sentAmountDate, bool isFinished )
       {
           return new PaymentTerm(mobileBankNo,payment,order, amount,mobileBankName,sentAmountDate,isFinished);
       }
    }
}
