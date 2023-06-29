using CarInformator.Models;
using CarInformator.Models.Historian;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carinformator.Data;
using Serilog;

namespace CarInformator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRepairHistorianContoller : ControllerBase
    {
        private readonly DataContext _context;
        public CarRepairHistorianContoller(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CarRepairHistorian>> GetCarRepairId(int id)
        {
            Log.Information("GetCarsRepair {id} at {RequestTime}",id, DateTime.Now);
            var carRepair = await _context.CarRepairs.FindAsync(id);
            if (carRepair == null)
                return BadRequest("Car Repair not found.");
            return Ok(carRepair);
        }
        [HttpPost]
        public async Task<ActionResult<List<CarRepairHistorian>>> AddRepair(CarRepairHistorian carRepair)
        {
            Log.Information("AddRepair at {RequestTime}", DateTime.Now);
            _context.CarRepairs.Add(carRepair);
            await _context.SaveChangesAsync();


            return Ok(carRepair);
        }
        [HttpPut]
        public async Task<ActionResult<List<CarRepairHistorian>>> UpdateCarRepair(CarRepairHistorian request)
        {
            Log.Information("UpdateCarRepair at {RequestTime}", DateTime.Now);
            var dbCarsRepair = await _context.CarRepairs.FindAsync(request.Id);
            if (dbCarsRepair == null)
                return BadRequest("Car not found.");


            dbCarsRepair.RepiarName = request.RepiarName;
            dbCarsRepair.RepiarDesc = request.RepiarDesc;
            dbCarsRepair.Price = request.Price;

            _context.Update(dbCarsRepair);
            await _context.SaveChangesAsync();

            return Ok(dbCarsRepair);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarRepairHistorian>> DeleteRepair(int id)
        {
            Log.Information("DeleteCarRepair at {RequestTime} ", DateTime.Now);
            var dbCarRepair = await _context.CarRepairs.FindAsync(id);
            if (dbCarRepair == null)
                return BadRequest("Car not found.");

            _context.CarRepairs.Remove(dbCarRepair);
            await _context.SaveChangesAsync();
            return Ok(dbCarRepair);
        }
    }
}
