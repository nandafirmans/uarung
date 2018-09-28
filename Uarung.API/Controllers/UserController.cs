using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Uarung.API.Model;
using Uarung.Data.Contract;

namespace Uarung.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IDacUser _dacUser;

        public UserController(IDistributedCache distributedCache, IDacUser dacUser)
        {
            _dacUser = dacUser;
        }

        //[HttpPost]
        //public ActionResult<BaseReponse> Insert([FromHeader] string sessionId)
        //{

        //}
    }
}
