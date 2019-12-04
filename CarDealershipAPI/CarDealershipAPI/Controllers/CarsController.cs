using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealershipAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
       
        private readonly CarDealershipDbContext _database;

        public CarsController(CarDealershipDbContext database)
        {
            _database = database;
        }
        //GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<List<Cars>>> GetCars()
        {
            //returning a list of cars

            return await _database.Cars.ToListAsync();
            //check URL @ https://localhost:44351/Api/Cars
        }

        //overloading the GET Method    

        //GET:api/Cars/1

        [HttpGet("{id}")]
        public async Task<ActionResult<Cars>> GetCarsById (int id)
        {
            //create a variable called car
            var car = await _database.Cars.FindAsync(id);
            // validation to make sure entered car exist
            if(car == null) 
            {
                return NotFound();

            }
            return car;
        }

        [HttpPost]

        public async Task<ActionResult<Cars>> PostCar(Cars car)
        {
            _database.Cars.Add(car);
            await _database.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarsById), new { id = car.CarId }, car);
        }
    }
}