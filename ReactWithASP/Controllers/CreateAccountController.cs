using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Data;
using ReactWithASP.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWithASP.Controllers
{
    [Route("api/create-account")]
    [ApiController]
    public class CreateAccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CreateAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.AgentName) ||
                string.IsNullOrWhiteSpace(request.AgentUsername) ||
                string.IsNullOrWhiteSpace(request.AgentPassword))
            {
                return BadRequest(new { message = "All fields are required." });
            }

            // Check if username already exists
            var existingAgent = await _context.Agents.FirstOrDefaultAsync(a => a.agentUsername == request.AgentUsername);
            if (existingAgent != null)
            {
                return BadRequest(new { message = "Username already exists." });
            }

            // Get highest current agentID and add 1
            int newAgentID = (_context.Agents.Max(a => (int?)a.agentId) ?? 0) + 1;

            var newAgent = new Agent
            {
                agentId = newAgentID,
                agentName = request.AgentName,
                agentUsername = request.AgentUsername,
                agentPassword = request.AgentPassword // Ideally, hash this for security
            };

            _context.Agents.Add(newAgent);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Account created successfully." });
        }
    }

    public class CreateAccountRequest
    {
        public string AgentName { get; set; }
        public string AgentUsername { get; set; }
        public string AgentPassword { get; set; }
    }
}

