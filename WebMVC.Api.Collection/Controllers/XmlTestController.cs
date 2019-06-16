using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebMVC.Service;

namespace WebMVC.Api.Collection.Controllers
{
    public class XmlTestController : BaseApiController
    {
        public IHttpActionResult GetXml(string key)
        {
            XmlService xml = new XmlService();
            return Json(xml.GetXmlNodeString(key));
        }
    }
    
}
