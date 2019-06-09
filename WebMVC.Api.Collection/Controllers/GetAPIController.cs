using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebMVC.Api.Collection.Controllers
{
    /// <summary>
    /// Get Type API Test
    /// </summary>
    public class GetAPIController : BaseApiController
    {
        /// <summary>
        /// 获取名称，内部制定
        /// </summary>
        /// <returns>名称</returns>
        [HttpGet]
        public IHttpActionResult GetName()
        {
            return Ok("mingsn");
        }

        /// <summary>
        /// 根据Id获取名称
        /// </summary>
        /// <param name="id">阿拉伯数字</param>
        /// <returns>查询的名称</returns>
        [HttpGet]
        public IHttpActionResult GetNameById(int id)
        {
            switch (id)
            {
                case 1:
                case 2:
                case 3:
                    return Ok("name(123)");
                default:
                    return Ok("mingsn xiaomi ningshu");
            }
        }

        /// <summary>
        /// 获取名称集合
        /// </summary>
        /// <param name="model">带有名字的对象</param>
        /// <returns>返回一个处理后的人物属性列表</returns>
        [HttpPost]
        public IHttpActionResult GetNameList(NameModel model)
        {
            List<NameModel> result = new List<NameModel>();
            result.Add(new NameModel { Name = model.Name + " - mingsn", Age = 22 });
            result.Add(new NameModel { Name = model.Name + " - 小米", Age = 22 });
            result.Add(new NameModel { Name = model.Name + " - 宁淑", Age = 22 });
            return Json(new { list = result });
        }

        /// <summary>
        /// 添加名称数据
        /// </summary>
        /// <param name="model">带有名字的对象</param>
        /// <returns>返回一个处理后的人物属性列表</returns>
        [HttpPost]
        public IHttpActionResult SetNameData(NameModel model)
        {
            string key = "NameModels";
            var list = (List<NameModel>)Cache.AddCahce(key, () => { return new List<NameModel>(); });
            if (!list.Contains(model))
            {
                list.Add(model);
                return Ok($"success hascode: {model.GetHashCode()}");
            }
            else
            {
                return Ok("exists");
            }
        }


        /// <summary>
        /// Name Object
        /// </summary>
        public class NameModel : IEquatable<NameModel>
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 年龄
            /// </summary>
            public int Age { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public bool Equals(NameModel other)
            {
                return this.Name == other.Name && this.Age == other.Age;
            }
        }
    }
}
