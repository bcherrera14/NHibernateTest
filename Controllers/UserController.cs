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
    public class UserController : ControllerBase
    {
        // private static ISessionFactory _sessionFactory;
        // public UserController(ISessionFactory factory){
        //     _sessionFactory = factory;
        // }
        [HttpGet("api/users")]
        public ActionResult GetUsers() {
            return Ok("Users!");
        }

        // public ActionResult<IEnumerable<User>> Get() {
        //     using (var session = _sessionFactory.OpenSession()) {
        //     var query = session.Query<User>();
        //     return query.ToList();
        //     }
        // }
    }
}
