using System;
using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public class SaleEstate: Estate
    {
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue,
                    ErrorMessage = "Введите корректное значение цены продажи")]
        public decimal SalePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal PerSquareMeterSalePrice
        {
            get
            {
                return Convert.ToDecimal(SalePrice / Convert.ToDecimal(Area));
            }
        }


        public int? SaleTreatyID { get; set; }

        public override bool SaleStatus
        {
            get
            {
                if (SaleTreatyID != null)
                    return true;
                else
                    return false;
            }
        }
        public SaleTreaty SaleTreaty { get; set; }
    }
}
