using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalExpensesManager.Model;
using PersonalExpensesManager.Model.Configurations;
using PersonalExpensesManager.Requests;

namespace PersonalExpensesManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShopsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShop()
        {
            return await _context.Shops.ToListAsync();
        }

        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }

        // PUT: api/Shops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShop(int id, ShopRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var shop = _context.Shops.FirstOrDefault(x => x.Id == id);

            if (shop == null)
            {
                return NotFound();
            }

            shop.Address = request.Address;
            shop.Description = request.Description;
            shop.Name = request.Name;

            _context.Entry(shop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Shops
        [HttpPost]
        public async Task<ActionResult<Shop>> PostShop(ShopRequest request)
        {
            var shop = new Shop()
            {
                Address = request.Address,
                Name = request.Name,
                Description = request.Description
            };

            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShop", new { id = shop.Id }, shop);
        }

        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopExists(int id)
        {
            return _context.Shops.Any(e => e.Id == id);
        }
    }
}
