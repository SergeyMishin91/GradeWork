using EstateAgency.Data;
using EstateAgency.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Models
{
    public class Statistic
    {
        private readonly EstateAgencyContext _context;
        
        public Statistic(EstateAgencyContext context)
        {
            _context = context;
        }

        public List<DemandForRentTypeEstateViewModel> DemandForRentTypeEstate()
        {
            var leases = _context.Leases;
            var estateLeases = _context.RentEstate_Leases;
            var estates = _context.RentEstates;

            var estateTypes = _context.Estates
                .Select(e => e.Type)
                .Distinct()
                .ToList();

            List<DemandForRentTypeEstateViewModel> pieData = new List<DemandForRentTypeEstateViewModel>();

            foreach (var estateType in estateTypes)
            {
                int count = 0;
                foreach (RentEstate estate in estates)
                {
                    if (estateType == estate.Type)
                    {
                        foreach (RentEstate_Lease rl in estateLeases)
                        {
                            if (rl.EstateID == estate.ID)
                            {
                                foreach (var lease in leases)
                                {
                                    if((lease.ID==rl.LeaseID)&&(lease.EndDate>DateTime.Now))
                                    {
                                        count++;
                                        break;
                                    }
                                }
                                break;
                            }
                            else
                                continue;
                        }
                    }   
                    else
                        continue;
                }
                pieData.Add(new DemandForRentTypeEstateViewModel
                {
                    EstateType = estateType,
                    QuantityEstateTypes = count
                });
            }
            return pieData;
        }

        public List<RentPriceForMonthViewModel> StatisticRentPriceForMonth(int _year)
        {
            var leases = _context.Leases;
            int year = 2017;


            List<RentPriceForMonthViewModel> lineChart = new List<RentPriceForMonthViewModel>();

            foreach (int m in Enum.GetValues(typeof(Month)))
            {
                int count = 0;
                decimal rentSum = 0;

                foreach (var lease in leases)
                {
                    if ((lease.SignDate.Month == m + 1)&&(lease.SignDate.Year==_year))
                    {
                        count++;
                        rentSum += lease.TotalRentPrice;
                    }
                    else
                        continue;
                }

                if (count > 0)
                {
                    lineChart.Add(new RentPriceForMonthViewModel
                    {
                        Month = (Month)m,
                        AverageRent = rentSum / count
                    });
                }

            }

            return lineChart;
        }

        public List<SalePriceForMonthViewModel> StatisticSalePriceForMonth(int _year)
        {
            var saleTreaties = _context.SaleTreaties
                .Where(s => s.SignDate.Year == _year)
                .ToList();


            List<SalePriceForMonthViewModel> lineChart = new List<SalePriceForMonthViewModel>();

            foreach (int m in Enum.GetValues(typeof(Month)))
            {
                int count = 0;
                decimal saleSum = 0;

                foreach (var saleTreaty in saleTreaties)
                {
                    if (m + 1 == saleTreaty.SignDate.Month)
                    {
                        count++;
                        saleSum += saleTreaty.TotalSalePrice;
                    }
                    else
                        continue;
                }

                if (count > 0)
                {
                    lineChart.Add(new SalePriceForMonthViewModel
                    {
                        Month = (Month)m,
                        AverageSale = saleSum / count
                    });
                }
            }

            return lineChart;
        }
    }
}
