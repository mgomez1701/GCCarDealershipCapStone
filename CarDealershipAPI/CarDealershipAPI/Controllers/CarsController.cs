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

        //PUTTing to the API
        //PUT:api/Company{id}

        [HttpPut("{id}")]
        public async Task<ActionResult>PutCar(int id, Cars car)
        {
            // cheking to make sure the car macthes up by id
            if (id != car.CarId)
            {
                return BadRequest();
            }

            _database.Entry(car).State = EntityState.Modified;
            await _database.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCar(int id)
        {
            var car = await _database.Cars.FindAsync(id);
            if(car == null)
            {
                return NotFound();
            }
            _database.Cars.Remove(car);
            await _database.SaveChangesAsync();
            return NoContent();
        }

        //[HttpGet("search")]
        //public async Task<IActionResult>


    }
}