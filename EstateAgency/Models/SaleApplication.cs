using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Models
{
    public class SaleApplication: Application
    {
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue,
                    ErrorMessage = "Введите корректное значение цены продажи")]
        public decimal SalePrice { get; set; }

    }
}
