﻿using CarInformator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carinformator.Data;
using CarInformator.Models.Historian;
using Microsoft.IdentityModel.Tokens;
using Serilog;

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
            Log.Information("{time}:GetCars:{time}",DateTimeOffset.UtcNow);
            Log.Warning("Processing request from {Car}", GetCars);
            var cars = await _context.Cars.Take(3).ToListAsync();
            return Ok(cars);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarId(int id)
        {
            //Log.Information("{time}:GetCar:{time}", DateTimeOffset.UtcNow);
            Log.Information("GetCar {Id} at {RequestTime}", id, DateTime.Now);
            Log.Warning("Processing request from {Car}", GetCarId);
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return BadRequest("Car not found.");
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            Log.Information("AddCar at {RequestTime}", DateTime.Now);
            Log.Warning("Processing request from {Car}", AddCar);
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();


            return Ok(car);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Car>>> UpdateCar(int id, Car request)
        {
            Log.Information("UpdateCars at {RequestTime}", DateTime.Now);
            Log.Warning("Processing request from {Car}", UpdateCar);
            var dbCar = await _context.Cars.FindAsync(id);
            if (dbCar == null)
                return BadRequest("Car not found");


            dbCar.Brand = request.Brand;
            dbCar.Model = request.Model;
            dbCar.Generation = request.Generation;
            dbCar.ProductionYear = request.ProductionYear;
            dbCar.UserId = request.UserId;

            _context.Update(dbCar);
            await _context.SaveChangesAsync();

            return Ok(dbCar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            Log.Information("DeleteCars {RequestTime}", DateTime.Now);
            Log.Warning("Processing request from {Car}", DeleteCar);
            var dbCars = await _context.Cars.FindAsync(id);
            if (dbCars == null)
                return BadRequest("Car not found.");

            _context.Cars.Remove(dbCars);
            await _context.SaveChangesAsync();
            return Ok(dbCars);
        }
    }
    
}
