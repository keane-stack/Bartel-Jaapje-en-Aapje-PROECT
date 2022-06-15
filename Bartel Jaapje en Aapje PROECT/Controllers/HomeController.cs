using Bartel_Jaapje_en_Aapje_PROECT.Database;
using Bartel_Jaapje_en_Aapje_PROECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            var films = GetAllFilms();

            // de lijst met namen in de html stoppen
            return View(films);
        }

        public List<Film> GetAllFilms()
        {
            var rows = DatabaseConnector.GetRows("select * from film");

            List<Film> films = new List<Film>();

            foreach (var row in rows)
            {
                Film f = new Film();

                f.Id = Convert.ToInt32(row["id"]);
                f.Titel = row["titel"].ToString();
                f.Duur = row["duur"].ToString();
                f.Poster = row["poster"].ToString();
                f.Beschrijving = row["beschrijving"].ToString();

                films.Add(f);

            }

            return films;
        }

        public Film GetFilm(int id)
        {
            var rows = DatabaseConnector.GetRows($"select * from film where id = {id}");

            List<Film> films = new List<Film>();

            foreach (var row in rows)
            {
                Film f = new Film();

                f.Id = Convert.ToInt32(row["id"]);
                f.Titel = row["titel"].ToString();
                f.Duur = row["duur"].ToString();
                f.Poster = row["poster"].ToString();
                f.Beschrijving = row["beschrijving"].ToString();

                films.Add(f);

            }

            return films[0];
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
            var film = GetFilm(id);

            return View(film);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
 