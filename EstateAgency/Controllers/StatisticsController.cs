using System;
using System.Collections.Generic;
using EstateAgency.Data;
using EstateAgency.Models;
using Microsoft.AspNetCore.Mvc;
using EstateAgency.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EstateAgency.Controllers
{
    public struct PieSeriesData
    {
        public string EstateType { get; set; }
        public int QuantityEstateTypes { get; set; }
    }

    public class StatisticsController : Controller
    {
        private readonly EstateAgencyContext _context;

        public StatisticsController(EstateAgencyContext context)
        {
            _context = context;
        }

        public ActionResult RentTypesAnalize()
        {
            Statistic stat = new Statistic(_context);
            List<DemandForRentTypeEstateViewModel> list = new List<DemandForRentTypeEstateViewModel>();
            list = stat.DemandForRentTypeEstate();
            return View(list);
            
        }

        public ActionResult StatisticAverageRent(int selectedYear)
        {
            GetYear(selectedYear);
            Statistic statistic = new Statistic(_context);
            List<RentPriceForMonthViewModel> rentPrices = new List<RentPriceForMonthViewModel>();
            rentPrices = statistic.StatisticRentPriceForMonth(selectedYear);
            return View(rentPrices);
        }

        public ActionResult StatisticAverageSale(int selectedYear)
        {
            GetYear(selectedYear);
            Statistic statistic = new Statistic(_context);
            List<SalePriceForMonthViewModel> salePrices = new List<SalePriceForMonthViewModel>();
            salePrices = statistic.StatisticSalePriceForMonth(selectedYear);
            return View(salePrices);
        }

        private void GetYear(int year)
        {
            int i;
            List<int> yearList = new List<int>();
            for (i = 2000; i <= DateTime.Now.Year; i++)
            {
                yearList.Add(i);
            }
            ViewBag.Year = new SelectList(yearList, year);
        }
    }
}