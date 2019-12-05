using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CarDealerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerApp.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>AddCar(Cars car)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/");

            var response = await client.PostAsJsonAsync("api/Cars", car);
            return RedirectToAction("Index");

        }
    }
}