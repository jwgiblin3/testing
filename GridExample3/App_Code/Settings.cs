using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridExample3.App_Code
{
    public class Settings
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
    }
}