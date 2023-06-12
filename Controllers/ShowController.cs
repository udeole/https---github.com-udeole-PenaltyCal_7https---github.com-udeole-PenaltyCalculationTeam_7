using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PenaltyCal_7.Models;
using System.Linq;

namespace PenaltyCal_7.Controllers
{
    public class ShowController : Controller
    {
        private readonly PenaltyCalContext _dbContext;

        public ShowController(PenaltyCalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ReferenceData()
        {
            // Retrieve data from the HolidayCalenders table
            var holidays = _dbContext.HolidayCalenders.ToList();

            // Retrieve data from the Securities table
            var securities = _dbContext.SecurityPrices.ToList();

            // Retrieve data from the SecurityPenaltyRates table
            var penaltyRates = _dbContext.SecurityPenaltyRates.ToList();

            // Pass the retrieved data to the view
            ViewData["Holidays"] = holidays;
            ViewData["Securities"] = securities;
            ViewData["PenaltyRates"] = penaltyRates;

            return View("ReferenceData");
        }







        public IActionResult Report()
        {
            return View("ReportOptions");
        }

        public IActionResult Penalty()
        {
            return View("PenaltyOptions");
        }

        public IActionResult ViewAllPenalties()
        {
            // Assuming you have a DbContext instance to work with the database
            List<Transaction> transactions = _dbContext.Transactions.ToList();

            return View("AllPenalties", transactions);
        }


        public IActionResult DailyPenaltyReport()
        {


            return View();
        }



        public IActionResult MonthlyPenaltyReport()
        {

            return View();
        }

        public IActionResult SearchResults(string id, string tableName)
        {
            // Retrieve the search results based on the provided id and tableName
            List<HolidayCalender> holidays = new List<HolidayCalender>();
            List<SecurityPrice> securities = new List<SecurityPrice>();
            List<SecurityPenaltyRate> penaltyRates = new List<SecurityPenaltyRate>();

            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(tableName))
            {
                // Apply the filtering logic based on id and tableName
                switch (tableName.ToLower())
                {
                    case "holidaycalender":
                        long holidayId;
                        if (long.TryParse(id, out holidayId))
                        {
                            holidays = _dbContext.HolidayCalenders.Where(h => h.HolidayId == holidayId).ToList();
                        }
                        break;
                    case "securityprice":
                        long priceId;
                        if (long.TryParse(id, out priceId))
                        {
                            securities = _dbContext.SecurityPrices.Where(s => s.PriceId == priceId).ToList();
                        }
                        break;
                    case "securitypenaltyrate":
                        long penaltyId;
                        if (long.TryParse(id, out penaltyId))
                        {
                            penaltyRates = _dbContext.SecurityPenaltyRates.Where(p => p.PenaltyId == penaltyId).ToList();
                        }
                        break;
                    default:
                        break;
                }
            }


            ViewData["Holidays"] = holidays;
            ViewData["Securities"] = securities;
            ViewData["PenaltyRates"] = penaltyRates;

            return View();
        }

        public IActionResult Holidays()
        {
            var holidays = _dbContext.HolidayCalenders.ToList();
            return View(holidays);
        }

        public IActionResult Securities()
        {
            var securities = _dbContext.SecurityPrices.ToList();
            return View(securities);
        }

        public IActionResult PenaltyRates()
        {
            var penaltyRates = _dbContext.SecurityPenaltyRates.ToList();
            return View(penaltyRates);
        }









    }
}

