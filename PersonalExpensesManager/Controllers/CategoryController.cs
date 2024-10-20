using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using PersonalExpensesManager.Model;
using PersonalExpensesManager.Model.Configurations;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

namespace PersonalExpensesManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        public readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext, ILogger<CategoryController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var result = await _dbContext.Categories.FirstOrDefaultAsync(item => item.Id == id);
            return result != null ? result : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Category>> PostCategory(Category request)
        {
            try
            {
                var result = await _dbContext.Categories.AddAsync(request);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction("GetCategory", new { id = result.Entity.Id }, result.Entity);
            }
            catch (DbUpdateException ex)
            {
                if (CategoryExists(request.Id))
                {
                    return Conflict();
                }

                _logger.LogError(ex, "Category Creation Exception");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected Exception");
                throw;
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> PutCategory(int id, Category request)
        {
            try
            {
                if (id != request.Id)
                {
                    return BadRequest();
                }

                var category = await _dbContext.Categories.FirstOrDefaultAsync(a => a.Id == id);
                if (category != null)
                {
                    category.Name = request.Name;
                    category.Description = request.Description;
                    await _dbContext.SaveChangesAsync();
                    return category;
                }

                return NotFound();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Category Creation Exception");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception");
                throw;
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(a => a.Id == id);
                if (category != null)
                {
                    _dbContext.Remove(category);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }

                return NotFound();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Category Deletion Exception");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected Exception");
                return StatusCode(500);
            }
        }

        private bool CategoryExists(int id)
        {
            return _dbContext.Categories.Any(e => e.Id == id);
        }
    }
}
