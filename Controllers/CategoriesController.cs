using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data;
using MyWebApi.Models;
using System.Security.Claims;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔐 Login required
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // Create Category
        // =========================
        [HttpPost]
        public async Task<IActionResult> CreateCategory(
   
            [FromBody] CreateCategoryRequest request)
        {
            // 1. Get UserId from JWT
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            // 2. Create Category
            var category = new Category
            {
                Name = request.Name,
                UserId = userId
            };

            // 3. Save to DB
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Category created successfully",
                CategoryId = category.Id
            });
        }
        [HttpGet]
        public string Get()
        {
            return "API is working!";
        }
    }





}
