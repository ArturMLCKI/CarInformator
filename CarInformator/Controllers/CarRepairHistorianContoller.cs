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
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CarRepairHistorian>> GetIdCarRepair(int id)
        {
            var carRepair = await _context.CarRepairs.FindAsync(id);
            if (carRepair == null)
                return BadRequest("Car Repair not found.");
            return Ok(carRepair);
        }
    }
}
