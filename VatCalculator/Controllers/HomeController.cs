using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VatCalculator.Models;
using VatCalculatorApi.DAL.Contracts;
using VatCalculatorApi.DAL.Models;

namespace VatCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculateVatRepository _repo;

        public HomeController(ILogger<HomeController> logger,ICalculateVatRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(UserInputsModel userInputs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(userInputs);
                }
                //UserOutputModel userOutput = new();
                var result = _repo.CalculateValueAddedTaxTest(userInputs);
                //userOutput = result;
                return View(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured");
                return null;
            }
            
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
