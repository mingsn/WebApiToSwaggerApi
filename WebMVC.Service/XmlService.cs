using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Service
{
    public class XmlService
    {
        public List<string> GetXmlNodeString(string key)
        {
            return Sql.SqlContext.GetSql(key);
        }
    }
}
