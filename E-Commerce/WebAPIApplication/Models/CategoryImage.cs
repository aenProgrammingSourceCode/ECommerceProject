using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class CategoryImage
    {
        public IEnumerable<CategoryImageView> CategoryImages { get; set; }
    }
}