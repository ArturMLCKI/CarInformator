using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarInformator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRepairHistorianContoller : ControllerBase
    {
        //private readonly DataContext _context;
        //public async Task<ActionResult<IEnumerable<CarRepairHistorianContoller>>> GetCarRepairs(int carId)
        //{
        //    var repairs = await _context.CarRepairs
        //        .Where(r => r.CarId == carId)
        //        .ToListAsync();
        //
        //    if (repairs == null || repairs.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(repairs);
        //}
    }
}
