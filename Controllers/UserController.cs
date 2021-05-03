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


        [HttpPost("api/users")]
        public ActionResult PostUser(string id, string firstname, string lastname)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var newUser = new User();
                    newUser.id = Int32.Parse(id);
                    newUser.firstname = firstname;
                    newUser.lastname = lastname;


                    session.Save(newUser);
                    transaction.Commit();
                }
            }
            return Ok(string.Format("Created Users {0}: {1} {2}", id, firstname, lastname));
        }

    }
}
