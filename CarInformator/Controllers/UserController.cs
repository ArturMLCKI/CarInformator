using CarInformator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Carinformator.Data;

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
            var users = await _usercontext.Users.Take(3).ToListAsync();

            foreach (var user in users)
            {
                var cars = await _context.Cars.Where(c => c.UserId == user.UserId).ToListAsync();
                user.Cars = cars;
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserWithCars(int id)
        {
            var user = await _usercontext.Users.Include(u => u.Cars).FirstOrDefaultAsync(c=> c.UserId == id);

            if (user == null)
            {
                return NotFound(); // Zwróć odpowiedź 404 Not Found, jeśli użytkownik nie został znaleziony
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddCar(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User request)
        {

            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
                return NotFound("Car not found.");


            dbUser.Name = request.Name;
            dbUser.Email = request.Email;
            dbUser.DrivingExp = request.DrivingExp;


            _context.Update(dbUser);
            await _context.SaveChangesAsync();

            return Ok(dbUser);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var dbUsers = await _context.Users.FindAsync(id);
            if (dbUsers == null)
                return BadRequest("Car not found.");

            _context.Users.Remove(dbUsers);
            await _context.SaveChangesAsync();
            return Ok(dbUsers);
        }
    }
}
