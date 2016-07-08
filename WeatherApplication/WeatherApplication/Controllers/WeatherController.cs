using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApplication.Services;

namespace WeatherApplication.Controllers
{
    public class WeatherController : Controller
    {
        private WeatherService service;
        // GET: Weather
        public WeatherController()
        {
            service = new WeatherService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWeather(string city,int term)
        {
            if (city == "")
                RedirectToAction("Index", "WeatherController");
            var result = service.GetWeatherForecast(city);
            ViewBag.days = term;
            return View(result);
        }

    }
}