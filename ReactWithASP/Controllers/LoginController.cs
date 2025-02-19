using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Data;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LoginController(ApplicationDbContext context)
    {
        _context = context;
    }

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