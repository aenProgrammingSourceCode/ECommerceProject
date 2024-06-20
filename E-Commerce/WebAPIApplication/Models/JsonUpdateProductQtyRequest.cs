using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class JsonUpdateProductQtyRequest
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}