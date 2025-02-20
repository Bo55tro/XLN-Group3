using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Data; // Include this for ApplicationDbContext
using ReactWithASP.Models;
using Microsoft.Extensions.Logging; // Add for logging
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ReactWithASP.Controllers
{
    [Route("api/forgot-password")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ForgotPasswordController> _logger; // Add logger

        // Inject the logger
        public ForgotPasswordController(ApplicationDbContext context, ILogger<ForgotPasswordController> logger)
        {
            _context = context;
            _logger = logger; // Initialize logger
        }

        // POST api/forgot-password
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                // Check if the user exists in the database
                var agent = await _context.Agents
                    .FirstOrDefaultAsync(a => a.agentUsername == request.agentUsername);

                if (agent == null)
                {
                    // Log the error and return "Not Found"
                    _logger.LogWarning($"User not found: {request.agentUsername}");
                    return NotFound(new { message = "User not found." });
                }

                // Send password to the email
                var emailData = new
                {
                    service_id = "service_g5n45yr", // Your EmailJS service ID
                    template_id = "template_2mn2cth", // Your EmailJS template ID
                    user_id = "gq61Nn5s6VpXSX2_e", // Your EmailJS public key
                    template_params = new
                    {
                        to_email = request.Email, // Recipient email
                        username = agent.agentUsername, // Username from DB
                        password = agent.agentPassword // Password from DB (DO NOT store passwords like this in production)
                    }
                };

                // Serialize the email data to JSON
                var jsonContent = JsonConvert.SerializeObject(emailData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                // Send the email via EmailJS API
                var response = await client.PostAsync("https://api.emailjs.com/api/v1.0/email/send", content);

                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"EmailJS Response: {responseBody}");

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Password reset email sent successfully to {request.Email}");
                    return Ok(new { message = "Password reset email sent successfully." });
                }
                else
                {
                    // Log the error response for debugging
                    _logger.LogError($"Failed to send email. Status Code: {response.StatusCode}");
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Error response: {errorResponse}");

                    return StatusCode(500, new { message = "Failed to send password reset email." });
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions and log them
                _logger.LogError($"Exception occurred: {ex.Message}");
                _logger.LogError($"Stack Trace: {ex.StackTrace}");

                return StatusCode(500, new { message = "Internal server error." });
            }
        }
    }

    // DTO for the ResetPasswordRequest body
    public class ResetPasswordRequest
    {
        public string agentUsername { get; set; }
        public string Email { get; set; }
    }
}








