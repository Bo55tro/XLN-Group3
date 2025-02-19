using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Data;
using ReactWithASP.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReactWithASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null ||
                string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Invalid login request.");
            }

            // Look up the agent using the provided username.
            var agent = await _context.Agents.FirstOrDefaultAsync(a => a.agentUsername == request.Username);

            // Check if the agent exists and the provided password matches.
            // (Note: For security reasons, consider storing hashed passwords and comparing hashes.)
            if (agent == null || agent.agentPassword != request.Password)
            {
                return Unauthorized("Invalid credentials.");
            }

            // Create claims for the user (you can add more claims as needed).
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Username)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Create authentication properties (e.g., persistent cookie if "Remember Me" is checked)
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = request.RememberMe
            };

            // Sign in the user and issue the authentication cookie.
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Ok(new { success = true, message = "Logged in successfully" });
        }
    }
}
