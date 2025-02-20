using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Data; // Add this to reference ApplicationDbContext
using ReactWithASP.Models;

namespace ReactWithASP.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST api/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var agent = await _context.Agents
                .FirstOrDefaultAsync(a => a.agentUsername == request.agentUsername && a.agentPassword == request.agentPassword);

            if (agent == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            return Ok(new { message = "Login successful." });
        }
    }

    // DTO for the login request
    public class LoginRequest
    {
        public string agentUsername { get; set; }
        public string agentPassword { get; set; }
    }
}






