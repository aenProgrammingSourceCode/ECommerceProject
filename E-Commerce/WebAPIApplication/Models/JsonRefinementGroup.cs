using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class JsonRefinementGroup
    {
        public int GroupId { get; set; }
        public int[] SelectedRefinements { get; set; }
    }
}