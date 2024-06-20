using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class BasketSummaryView
    {
        public int NumberOfItems { get; set; }
        public string BasketTotal { get; set; }
    }
}