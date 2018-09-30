using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Uarung.API.Utility;
using Uarung.Data.Contract;

namespace Uarung.API.Controllers
{
    public class TestController : BaseController
    {
        private readonly IDacProduct _dacProduct;
        private readonly IDacUser _dacUser;

        public TestController(
            IDacUser dacUser,
            IDacProduct dacProduct,
            IDistributedCache distributedCache
        )
        {
            _dacUser = dacUser;
            _dacProduct = dacProduct;
        }
        
        [HttpGet("{id}")]
        [UnAuthorize]
        public ActionResult<string> Insert(string id)
        {
            return Crypt.ToMD5(id);
        }
    }
}