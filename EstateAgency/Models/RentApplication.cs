using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public class RentApplication: Application
    {
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Введите корректное значение цены аренды")]
        public decimal RentPrice { get; set; }

    }
}
