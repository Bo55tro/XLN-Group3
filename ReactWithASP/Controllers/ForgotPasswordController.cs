using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ReactWithASP;
using Microsoft.EntityFrameworkCore;

namespace ReactWithASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Inject the ApplicationDbContext into the controller
        public ForgotPasswordController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            // Check if username and email are provided
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Email))
            {
                return BadRequest("Username and email are required.");
            }

            // Look up the user by username
            var agent = await _context.Agents
                .FirstOrDefaultAsync(a => a.agentUsername == request.Username);

            // Check if the user exists
            if (agent == null)
            {
                return NotFound("Username not found.");
            }

            // Here you would typically check if the email matches the one on record.
            // Since email isn't stored, we skip that step for now. You can add more validation if needed.

            string password = agent.agentPassword; // Retrieve the password from the database

            // Set up SMTP client (using Gmail as an example)
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ajack200447@gmail.com", "jtqgkzvddqgfrvck"), // Use your app password here
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("ajack200447@gmail.com"),
                Subject = "Password Recovery",
                Body = $"Hello {request.Username},\n\nYour password is: {password}\n\nWORK IN PROGRESS",
                IsBodyHtml = false,
            };

            mailMessage.To.Add(request.Email);

            try
            {
                // Send the email
                await smtpClient.SendMailAsync(mailMessage);
                return Ok(new { message = "Password recovery email sent." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error sending email: {ex.Message}" });
            }
        }
    }

    public class ForgotPasswordRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}




