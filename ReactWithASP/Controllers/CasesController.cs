using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Data;
using ReactWithASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using ReactWithASP.Utilities;
using System;
using System.Text.RegularExpressions;

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

            
            if (!string.IsNullOrWhiteSpace(newCase.caseComments))
            {
                newCase.caseKeyWords = string.Join(",", KeywordExtractor.ExtractKeywords(newCase.caseComments));
            }
            else
            {
                newCase.caseKeyWords = ""; // Prevents null references
            }

            Console.WriteLine($"Extracted Keywords: {newCase.caseKeyWords}");

            
            if (!DateTime.TryParse(newCase.caseDate.ToString(), out DateTime parsedDate))
            {
                return BadRequest(new { message = "Invalid date format. Please use YYYY-MM-DD." });
            }

            newCase.caseDate = parsedDate.Date; // Stores only the date part


            // Log the incoming data for debugging help
            Console.WriteLine($"Received case: {JsonSerializer.Serialize(newCase)}");

            // Check for missing required fields
            if (newCase.CategoryId == 0 || newCase.ReasonId == 0 || newCase.DetailId == 0 || newCase.ClientId == 0)
            {
                return BadRequest("Missing required fields.");
            }

            // Check for duplicate cases before saving
            var existingCases = _context.Cases
                .Where(c => c.CategoryId == newCase.CategoryId && c.ReasonId == newCase.ReasonId)
                .ToList();

            foreach (var existingCase in existingCases)
            {
                var existingKeywords = existingCase.caseKeyWords.Split(',').ToList();
                var newKeywords = newCase.caseKeyWords.Split(',').ToList();

                int commonWords = existingKeywords.Intersect(newKeywords).Count();

                if (commonWords >= 3) 
                {
                    return Conflict(new { message = "Potential duplicate case found.", existingCase });
                }
            }


            using (var transaction = await _context.Database.BeginTransactionAsync()) {
                try
                {
                    _context.Cases.Add(newCase);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok(newCase);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine($"Error inserting case: {ex.Message}");
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }
    }
}
