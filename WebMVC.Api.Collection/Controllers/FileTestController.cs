using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebMVC.Api.Collection.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class FileTestController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetTempFileName()
        {
            return Json(new {
                TempFileName = Path.GetTempFileName()
            });
        }

        /// <summary>
        /// 创建并覆盖
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult CreateFile()
        {
            string path = $@"E:\FlieTest\mingsn.json";
            FileInfo fileInfo = new FileInfo(path);
            var json = new { name = "mingsn", brith = "1996-08-31", sex = 1, create = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") };
            string jsonContent = JsonConvert.SerializeObject(json);
            byte[] json_bt = Encoding.Default.GetBytes(jsonContent);
            using (FileStream fs = fileInfo.Create())
            {
                fs.Write(json_bt, 0, json_bt.Length);
            }
            return Json(new {
                path,
                json
            });
        }


        /// <summary>
        /// 创建并覆盖
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult CreateFile(string path)
        {
            
            path = string.IsNullOrWhiteSpace(path) ? $@"E:\FlieTest\mingsn.json" : path;
            //FileInfo fileInfo = new FileInfo(path);
            var json = new { name = "mingsn", brith = "1996-08-31", sex = 1, create = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") };
            string jsonContent = JsonConvert.SerializeObject(json);
            byte[] json_bt = Encoding.Default.GetBytes(jsonContent);
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                fs.Write(json_bt, 0, json_bt.Length);
            }
            
            return Json(new
            {
                path,
                json
            });
        }
    }
}
