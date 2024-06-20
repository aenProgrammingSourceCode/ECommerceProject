using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace alamapp.Infrastructure.CookieStorage
{
   public class CookieStorageService : alamapp.Infrastructure.CookieStorage.ICookieStorageService
    {
        public void Save(string key, string value, DateTime expires)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = expires;
        }

        public string Retrieve(string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
                return cookie.Value;
            return "";
        }
    }
}
