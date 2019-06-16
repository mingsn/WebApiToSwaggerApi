using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Service
{
    public class DbService
    {
        private readonly IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MingSnExplorer"].ConnectionString);
        public dynamic GetUser()
        {
            return connection.Query("SELECT * FROM MS_UserInfo");
        }
    }
}
