using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Models.ViewModels
{
    public class SalePriceForMonthViewModel
    {
        public Month Month { get; set; }

        public decimal AverageSale { get; set; }

    }
}
