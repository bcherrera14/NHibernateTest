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
                    /*newUser.id = Int32.Parse(id);*/

                    newUser.firstname = firstname;
                    newUser.lastname = lastname;


                    session.Save(newUser);
                    Console.WriteLine(newUser.id);
                    transaction.Commit();
                }
            }
            return Ok(string.Format("Created Users {0} {1}", firstname, lastname));
        }

        [HttpDelete("api/users")]
        public ActionResult DeleteUser(string id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user_id = Int32.Parse(id);
                    var user = session.Get<User>(user_id);
                    Console.WriteLine(user);

                    session.Delete(user);
                    transaction.Commit();
                }
            }
            return Ok(string.Format("Deleted Users with ID: {0}", id));
        }
    }
}
