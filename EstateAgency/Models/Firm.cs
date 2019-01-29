using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Models
{
    public class Firm : Client
    {
        [StringLength(50, ErrorMessage = "Наименование должно содержать от 1 до 50 символов")]
        public string CompanyName { get; set; }

        [Range(100000000, 999999999, ErrorMessage = "УНП должен содержать 9 цифр")]
        public int UNP { get; set; }

        public override string FullName
        {
            get => base.FullName = CompanyName;
        }
    }
}
