using Bartel_Jaapje_en_Aapje_PROECT.Database;
using Bartel_Jaapje_en_Aapje_PROECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bartel_Jaapje_en_Aapje_PROECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // alle producten ophalen
            var rows = Database.DatabaseConnector.GetRows("select * from film");

            // lijst maken om alle namen in te stoppen
            List<string> names = new List<string>();

            foreach (var row in rows)
            {
                // elke naam toevoegen aan de lijst met namen
                names.Add(row["titel"].ToString());
            }

            // de lijst met namen in de html stoppen
            return View(names);
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }


        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("Contact")]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
            {
                // todo opslaan in database
               return Redirect("/succes");
            }

            return View(person);
        }

        [Route("Kaartverkoop")]
        public IActionResult Kaartverkoop()
        {
            return View();
        }

        [Route("film/{id}")]
        public IActionResult FilmDetails(int id)
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
 