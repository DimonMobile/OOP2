using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    [Serializable]
    public class Univercity
    {
        public List<Student> Students { get; set; }
        public Address Address{get;set;}
        public Univercity()
        {
            Address = new Address();
            Students = new List<Student>();
        }
    }
}
