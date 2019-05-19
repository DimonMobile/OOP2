using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Record
    {   [Key]
        public string Fio { get; set; }
        public string Subject { get; set; }
        public DateTime Time { get; set; }
        public int Duration {get;set;}
        public Record(string Fio, string Subject, DateTime Time, int Duration)
        {
            this.Fio = Fio;
            this.Subject = Subject;
            this.Time = Time;
            this.Duration = Duration;
        }
    }
}
