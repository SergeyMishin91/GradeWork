using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Models.ViewModels
{
    public enum Month
    {
        Janury,
        February,
        March,
        April,
        May,
        June,
        Jule,
        August,
        September,
        October,
        November,
        December
    }

    public class RentPriceForMonthViewModel
    {
        public Month Month { get; set; }

        public decimal AverageRent { get; set; }
    }
}
