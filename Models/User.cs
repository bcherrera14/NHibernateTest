using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;

namespace Models
{

    public class User
    {
        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }

    }
}