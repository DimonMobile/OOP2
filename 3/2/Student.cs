using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2
{
    [Serializable]
    public class Student
    {
        [Required(ErrorMessage = "Отсутствует имя")]       
        public string Fio { get; set; }
        [Required(ErrorMessage = "Отсутствует дата рождения")]
        public DateTime Born {get;set;}
        [Required(ErrorMessage = "Отсутствует специальность")]
        public string Specialization { get; set; }
        [Required(ErrorMessage = "Отсутствует курс")]
        public int Cource { get; set; }
        [Required(ErrorMessage = "Отсутствует группа")]
        public int Group { get; set; }
        [Required(ErrorMessage = "Отсутствует средний балл")]
        public double Average { get; set; }
        [Required(ErrorMessage = "Отсутствует пол")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Отсутствует адрес")]
        public Address Address { get; set; }
    }
}
