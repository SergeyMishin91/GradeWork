using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public class Lease: Treaty
    {
        [DataType(DataType.Currency)]
        public decimal TotalRentPrice { get; set; }

        [Required(ErrorMessage = "Введите площадь недвижимого имущества")]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Введите корректное значение площади")]
        public double Area { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public ICollection<RentEstate_Lease> RentEstate_Leases { get; set; }

    }
}
