using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public class RentEstate: Estate
    {
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Введите корректное значение цены аренды")]
        public decimal PerSquareMeterRentPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal RentPrice
        {
            get
            {
                return Convert.ToDecimal(PerSquareMeterRentPrice * Convert.ToDecimal(Area));
            }
        }

        public ICollection<RentEstate_Lease> RentEstate_Leases { get; set; }
    }
}
