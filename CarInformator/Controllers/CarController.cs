using CarInformator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carinformator.Data;
using CarInformator.Models.Historian;

namespace CarInformator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly DataContext _context;
        public CarController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _context.Cars.Take(3).ToListAsync();
            return Ok(cars);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetId(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return BadRequest("Car not found.");
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();


            return Ok(car);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> UpdateCar(int id, Car request )
        {
            var dbCar = await _context.Cars.FindAsync(request.Id);
            if (dbCar == null)
                return NotFound("Car not found.");

            dbCar.Brand = request.Brand;
            dbCar.Model = request.Model;
            dbCar.Generation = request.Generation;
            dbCar.UserId = request.UserId;

            await _context.SaveChangesAsync();

            return Ok(dbCar);
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var dbCars = await _context.Cars.FindAsync(id);
            if (dbCars == null)
                return BadRequest("Car not found.");

            _context.Cars.Remove(dbCars);
            await _context.SaveChangesAsync();
            return Ok(dbCars);
        }
    }
    
}
