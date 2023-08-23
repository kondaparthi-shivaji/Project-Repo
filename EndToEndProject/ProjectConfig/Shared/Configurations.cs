using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ProjectConfig.Shared
{
    public class Configurations
    {

        private static string dbConnectionString;

        public static string DBConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(dbConnectionString))
                {
                    dbConnectionString = WebConfigurationManager.AppSettings["DefaultConnection"].ToString();
                }

                return dbConnectionString;
            }
            set
            {
                dbConnectionString = value;
            }
        }
    }
}
