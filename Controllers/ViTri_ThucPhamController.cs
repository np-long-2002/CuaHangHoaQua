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
    public class ViTri_ThucPhamController : ControllerBase
    {
        private readonly DataContext _context;

        public ViTri_ThucPhamController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ViTri_ThucPham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViTri_ThucPham>>> GetViTri_ThucPhams()
        {
          if (_context.ViTri_ThucPhams == null)
          {
              return NotFound();
          }
            return await _context.ViTri_ThucPhams.ToListAsync();
        }

        // GET: api/ViTri_ThucPham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViTri_ThucPham>> GetViTri_ThucPham(int id)
        {
          if (_context.ViTri_ThucPhams == null)
          {
              return NotFound();
          }
            var viTri_ThucPham = await _context.ViTri_ThucPhams.FindAsync(id);

            if (viTri_ThucPham == null)
            {
                return NotFound();
            }

            return viTri_ThucPham;
        }

        // PUT: api/ViTri_ThucPham/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViTri_ThucPham(int id, ViTri_ThucPham viTri_ThucPham)
        {
            if (id != viTri_ThucPham.ViTriId)
            {
                return BadRequest();
            }

            _context.Entry(viTri_ThucPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViTri_ThucPhamExists(id))
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

        // POST: api/ViTri_ThucPham
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViTri_ThucPham>> PostViTri_ThucPham(ViTri_ThucPham viTri_ThucPham)
        {
          if (_context.ViTri_ThucPhams == null)
          {
              return Problem("Entity set 'DataContext.ViTri_ThucPhams'  is null.");
          }
            _context.ViTri_ThucPhams.Add(viTri_ThucPham);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ViTri_ThucPhamExists(viTri_ThucPham.ViTriId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetViTri_ThucPham", new { id = viTri_ThucPham.ViTriId }, viTri_ThucPham);
        }

        // DELETE: api/ViTri_ThucPham/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViTri_ThucPham(int id)
        {
            if (_context.ViTri_ThucPhams == null)
            {
                return NotFound();
            }
            var viTri_ThucPham = await _context.ViTri_ThucPhams.FindAsync(id);
            if (viTri_ThucPham == null)
            {
                return NotFound();
            }

            _context.ViTri_ThucPhams.Remove(viTri_ThucPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViTri_ThucPhamExists(int id)
        {
            return (_context.ViTri_ThucPhams?.Any(e => e.ViTriId == id)).GetValueOrDefault();
        }
    }
}
