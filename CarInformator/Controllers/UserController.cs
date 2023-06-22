using CarInformator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarInformator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly DataContext _usercontext;
        public UserController(DataContext context, DataContext usercontext)
        {
            _context = context;
            _usercontext = usercontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersWithCars()
        {
            var users = await _usercontext.Users.ToListAsync();

            foreach (var user in users)
            {
                var cars = await _context.Cars.Where(c => c.Id == user.UserId).ToListAsync();
                user.Cars = cars;
            }

            return Ok(users);
        }
    }
}
