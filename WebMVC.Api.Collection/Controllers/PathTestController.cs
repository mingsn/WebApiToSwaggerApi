using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebMVC.Api.Collection.Controllers
{
    /// <summary>
    /// 路径测试
    /// </summary>
    public class PathTestController : BaseApiController
    {
        /// <summary>
        /// GetAppDomain
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAppDomain()
        {
            var app = AppDomain.CurrentDomain;
            return Json(new {
                app.BaseDirectory,
                app.RelativeSearchPath,
                app.DynamicDirectory,
                app.FriendlyName,
                Environment.CurrentDirectory,
                Environment.SystemDirectory,
                Environment.WorkingSet
            });
        }
    }
}
