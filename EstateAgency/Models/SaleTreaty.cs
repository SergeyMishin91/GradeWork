using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public class SaleTreaty: Treaty
    {
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Введите корректное значение цены продажи")]
        public decimal TotalSalePrice { get; set; }

        public ICollection<Estate> Estates { get; set; }
    }
}
