﻿using alamapp.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Orders
{
   public class PaymentView
    {
       public int Id { get; set; }
       public string PaymentDate { get; set; }
       public decimal Amount { get; set; }
       public string CreateDate { get; set; }
       public string MobileBankName { get; set; }
       public bool IsFinished { get; set; }
       public int MobileBankNo { get; set; }
       public string TransactionNo { get; set; }
    }
}
