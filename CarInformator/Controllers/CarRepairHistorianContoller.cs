using CarInformator.Models;
using CarInformator.Models.Historian;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    }
}
