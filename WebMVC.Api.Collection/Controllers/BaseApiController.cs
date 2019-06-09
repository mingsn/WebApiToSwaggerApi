using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebMVC.Service;

namespace WebMVC.Api.Collection.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        protected CacheService Cache { get; } = CacheService.Default;
    }
}
