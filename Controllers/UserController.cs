using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.NetCore;
using Models;

namespace NHibernateTest.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        public UserController(ISessionFactory factory) {
            this.factory = factory;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get() {
            using (var session = factory.OpenSession()) {
                var query = session.Query<User>();
                return query.ToList();
            }
        }
    }
}
