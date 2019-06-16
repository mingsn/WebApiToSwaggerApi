using System;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using WebMVC.Service;

namespace WebMVC.Api.Tests.Sql
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class UnitTest1
    {

        string XmlPath = "E:\\SQLXML";
        string name = "GetUserGroup";
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestXPathDocument()
        {
            XPathDocument xPath = new XPathDocument(XmlPath + "\\ComView.xml");
            XPathNavigator xPathNav = xPath.CreateNavigator();
            //使用xPath取rss中最新的10条随笔
            XPathNavigator sqlnav = xPathNav.SelectSingleNode($"ComView/sql[@name='{name}']");
            string sql1 = sqlnav.InnerXml;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestXmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlPath + "\\ComView.xml");
            //使用xPath选择需要的节点
            XmlNode node = doc.SelectSingleNode($"ComView/sql[@name='{name}']");
            string sql2 = node.InnerText;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestJsonDocument()
        {
            string str = File.ReadAllText("E:\\SQLJSON\\ComView.json");
            var sql = JsonConvert.DeserializeObject<jsonsql>(str);
            var s = sql;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestSrting()
        {
            string str = string.Join(",", "xiaomi", "xiaoming","ningshu");
            var s = str;
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestSqlQuery()
        {
            DbService db = new  DbService();
            var list = db.GetUser();
            var s = list;
        }


        /// <summary>
        /// 
        /// </summary>
        public class jsonsql
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("sqls")]
            public List<sqlinfo> Sqls{ get; set; }
            /// <summary>
            /// 
            /// </summary>
            public class sqlinfo
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty("name")]
                public string name { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty("value")]
                public string value { get; set; }
            }
        }
    }
}
