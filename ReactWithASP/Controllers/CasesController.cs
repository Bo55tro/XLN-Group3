using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Data;
using ReactWithASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace ReactWithASP.Controllers {
    [Route("api/cases")]
    [ApiController]
    public class CasesController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public CasesController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpGet("reasons/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Reason>>> GetReasons(int categoryId)
        {
            return await _context.Reasons
                .Where(r => r.CategoryId == categoryId)
                .ToListAsync();
        }

        [HttpGet("details/{reasonId}")]
        public async Task<ActionResult<IEnumerable<Detail>>> GetDetails(int reasonId)
        {
            return await _context.Details
                .Where(d => d.ReasonId == reasonId)
                .ToListAsync();
        }

        [HttpGet("clients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCase([FromBody] Case newCase)
        {
            if (newCase == null)
            {
                return BadRequest("Invalid case data: Request body is empty.");
            }

            // ✅ Ensure the date is properly parsed
            if (!DateTime.TryParse(newCase.caseDate.ToString(), out DateTime parsedDate))
            {
                return BadRequest(new { message = "Invalid date format. Please use YYYY-MM-DD." });
            }

            newCase.caseDate = parsedDate;

            // ✅ Debugging: Log the incoming data
            Console.WriteLine(JsonSerializer.Serialize(newCase));

            Console.WriteLine($"Received case: {JsonSerializer.Serialize(newCase)}");

            if (newCase.CategoryId == 0 || newCase.ReasonId == 0 || newCase.DetailId == 0 || newCase.ClientId == 0)
            {
                return BadRequest("Missing required fields.");
            }

            try
            {
                _context.Cases.Add(newCase);
                await _context.SaveChangesAsync();
                return Ok(newCase);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting case: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




    }
}