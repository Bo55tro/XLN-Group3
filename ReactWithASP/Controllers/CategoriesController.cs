using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Data;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]

public class CategoriesController : ControllerBase {
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet("categorieswithCaseCount")]
    public async Task<ActionResult> GetCategoriesWithCaseCount()
    {
        var categories = await _context.Categories.Select(c=> new
        {
            categoryId = c.categoryId,
            categoryName = c.categoryName,
            caseCount = _context.Cases.Count(cs => cs.CategoryId == c.categoryId) 
        }).ToListAsync();
        return Ok(categories);
    }
}