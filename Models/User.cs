using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;

namespace Models
{

    public class User
    {
        public virtual int id { get; set; }
        public virtual string firstname { get; set; }
        public virtual string lastname { get; set; }

    }
}