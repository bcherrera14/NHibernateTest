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
        private ISessionFactory _sessionFactory;
        public UserController(ISessionFactory factory)
        {
            _sessionFactory = factory;
        }
        [HttpGet("api/users")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var query = session.Query<User>();
                return query.ToList();
            }
        }

        [HttpGet("api/users/create")]
        public ActionResult Get()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var newUser = new User();
                    newUser.id = 3;
                    newUser.firstname = "John";
                    newUser.lastname = "Smith";
                 

                    session.Save(newUser);
                    transaction.Commit();
                }
                /*Console.ReadLine();*/
            }
            return Ok("Create Users!");
        }

    }
}
