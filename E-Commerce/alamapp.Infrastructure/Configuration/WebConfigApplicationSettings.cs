using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace alamapp.Infrastructure.Configuration
{
   public class WebConfigApplicationSettings:IApplicationSettings
    {
        public string NumberOfResultsPerPage
        {
            get { return ConfigurationManager.AppSettings["NumberOfResultsPerPage"]; }
        }
    }
}
