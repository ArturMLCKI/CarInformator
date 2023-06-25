using CarInformator.Models;
using CarInformator.Models.Historian;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carinformator.Data;

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
        public async Task<ActionResult<CarRepairHistorian>> GetId(int CarId)
        {
            var carRepair = await _context.CarRepairs.FindAsync(CarId);
            if (carRepair == null)
                return BadRequest("Car Repair not found.");
            return Ok(carRepair);
        }
        [HttpPut]
        public async Task<ActionResult<List<CarRepairHistorian>>> UpdateCarRepair(CarRepairHistorian request)
        {
            var dbCarsRepair = await _context.CarRepairs.FindAsync(request.Id);
            if (dbCarsRepair == null)
                return BadRequest("Car not found.");


            dbCarsRepair.RepiarName = request.RepiarName;
            dbCarsRepair.RepiarDesc = request.RepiarDesc;
            dbCarsRepair.Price = request.Price;
            dbCarsRepair.Date = request.Date;

            await _context.SaveChangesAsync();

            return Ok(await _context.Cars.ToListAsync());

        }
    }
}
