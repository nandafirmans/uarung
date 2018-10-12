using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Uarung.Data.Contract;

namespace Uarung.API.Controllers
{
    public class TestController : BaseController
    {
        private readonly IDacProduct _dacProduct;


        public TestController(
            IDacProduct dacProduct,
            IDistributedCache distributedCache
        )
        {
            _dacProduct = dacProduct;
        }
        
        [HttpGet()]
        public ActionResult<IEnumerable<Data.Entity.Product>> Get()
        {
            return _dacProduct.All().ToList();
        }
    }
}