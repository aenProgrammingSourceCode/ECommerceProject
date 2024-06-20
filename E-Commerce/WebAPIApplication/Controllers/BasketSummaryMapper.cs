using alamapp.ServiceImplementations.ViewModel.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public static class BasketSummaryMapper
    {
        public static BasketSummaryView ConvertToSummary(this BasketView basketView)
        {
            return new BasketSummaryView()
            {
                 BasketTotal=basketView.BasketTotal,
                 NumberOfItems=basketView.NumberOfItem
            };
        }
    }
}