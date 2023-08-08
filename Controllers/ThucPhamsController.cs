using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CuaHangHoaQua.Data;
using CuaHangHoaQua.Models;

namespace CuaHangHoaQua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThucPhamsController : ControllerBase
    {
        private readonly DataContext _context;

        public ThucPhamsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ThucPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThucPham>>> GetThucPhams()
        {
          if (_context.ThucPhams == null)
          {
              return NotFound();
          }
            return await _context.ThucPhams.ToListAsync();
        }

        // GET: api/ThucPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThucPham>> GetThucPham(int id)
        {
          if (_context.ThucPhams == null)
          {
              return NotFound();
          }
            var thucPham = await _context.ThucPhams.FindAsync(id);

            if (thucPham == null)
            {
                return NotFound();
            }

            return thucPham;
        }

        // PUT: api/ThucPhams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThucPham(int id, ThucPham thucPham)
        {
            if (id != thucPham.Id)
            {
                return BadRequest();
            }

            _context.Entry(thucPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThucPhamExists(id))
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

        // POST: api/ThucPhams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThucPham>> PostThucPham(ThucPham thucPham)
        {
          if (_context.ThucPhams == null)
          {
              return Problem("Entity set 'DataContext.ThucPhams'  is null.");
          }
            _context.ThucPhams.Add(thucPham);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThucPham", new { id = thucPham.Id }, thucPham);
        }

        // DELETE: api/ThucPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThucPham(int id)
        {
            if (_context.ThucPhams == null)
            {
                return NotFound();
            }
            var thucPham = await _context.ThucPhams.FindAsync(id);
            if (thucPham == null)
            {
                return NotFound();
            }

            _context.ThucPhams.Remove(thucPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThucPhamExists(int id)
        {
            return (_context.ThucPhams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
