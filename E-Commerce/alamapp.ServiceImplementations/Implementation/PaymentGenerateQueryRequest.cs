using alamapp.Infrastructure.Querying;
using alamapp.Model.Orders;
using alamapp.ServiceImplementations.Messaging.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class PaymentGenerateQueryRequest
    {
       public static Query CreatePaymentQuery(CreatePaymentRequest request)
       {
           Query paymentQuery = new Query();
           paymentQuery.Add(Criterion.Create<Payment>(p => p.IsConfirmed, 1, CriteriaOperator.Equal));
           return paymentQuery;
       }
    }
}
