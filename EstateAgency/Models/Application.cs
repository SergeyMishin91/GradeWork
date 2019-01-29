using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Models
{
    public class Application
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Наименование должно содержать от 1 до 50 символов")]
        public string ClientName { get; set; }

        [Required]
        [StringLength(25)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "ФИО должно содержать от 1 до 50 символов")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Введите тип недвижимого имущества")]
        public string EstateType { get; set; }

        [Required(ErrorMessage = "Введите площадь недвижимого имущества")]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Введите корректное значение площади")]
        public double EstateArea { get; set; }

        public string OtherRequirements { get; set; }

        public DateTime DateAdd
        {
            get
            {
                return DateTime.Now.Date;
            }
        }
    }
}
