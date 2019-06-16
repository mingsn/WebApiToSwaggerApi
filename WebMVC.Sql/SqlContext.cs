using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace WebMVC.Sql
{
    public static class SqlContext
    {
        private static string XmlPath { get; } = ConfigurationManager.AppSettings["SQL_XML_PATH"].ToString();

        public static List<string> GetSql(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            List<string> result = new List<string>();

            XPathDocument xPath = new XPathDocument(XmlPath + "\\ComView.xml");
            XPathNavigator xPathNav = xPath.CreateNavigator();
            //使用xPath取rss中最新的10条随笔
            XPathNavigator sqlnav = xPathNav.SelectSingleNode("ComView/sql[@name='GetUserGroup']");
            string sql1 = sqlnav.InnerXml;
            result.Add(sql1);


            XmlDocument doc = new XmlDocument();
            doc.Load(XmlPath + "\\ComView.xml");
            //使用xPath选择需要的节点
            XmlNode node = doc.SelectSingleNode("ComView/sql[@name='GetUserGroup']");
            string sql2 = node.InnerText;
            result.Add(sql2);
            return result;
        }
        
    }
}
