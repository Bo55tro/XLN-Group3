using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Data;
using ReactWithASP.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LoginController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost] 
    public async Task<IActionResult> Login([FromBody] LoginModel request)
    {
        // Check if agent exists with matching username and password
        var agent = await _context.Agents
            .FirstOrDefaultAsync(a => a.agentUsername == request.agentUsername);

        if (agent == null || agent.agentPassword != request.agentPassword)
        {
            return Unauthorized(new { message = "Invalid username or password." });
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, agent.agentUsername),
            new Claim("AgentId", agent.agentId.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true // Keep user logged in TEMP!
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);

        return Ok(new { message = "Login successful" });
    }
}
