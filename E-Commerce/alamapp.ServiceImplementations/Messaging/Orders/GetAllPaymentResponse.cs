﻿using alamapp.ServiceImplementations.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Orders
{
   public class GetAllPaymentResponse
    {
        public IEnumerable<PaymentView> Payments { get; set; }
    }
}
