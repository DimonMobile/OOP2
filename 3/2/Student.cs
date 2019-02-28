using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    [Serializable]
    public class Student
    {
        public string Fio { get; set; }
        public DateTime Born {get;set;}
        public string Specialization { get; set; }
        public int Cource { get; set; }
        public int Group { get; set; }
        public double Average { get; set; }
        public string Sex { get; set; }
        public Address Address { get; set; }
    }
}
