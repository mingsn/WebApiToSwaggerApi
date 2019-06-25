using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebMVC.Api.Collection.Controllers
{
    /// <summary>
    /// 并发测试
    /// </summary>
    public class ParallelTestController: BaseApiController
    {
        private static readonly object onLock = new object();
        private static bool isLock = false;

        /// <summary>
        /// 并发调用
        /// </summary>
        /// <param name="p">并发参数</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult ParallelInvoke(int p)
        {
            lock (onLock)
            {
                if (!isLock)
                {
                    isLock = !isLock;
                    return Json(new { result = $"第 {p} 个 请求" });
                }
                else
                {
                    return Json(new { result = $"神之无知 {p}" });
                }
            }
        }
    }
}
