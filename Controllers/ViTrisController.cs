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
    public class ViTrisController : ControllerBase
    {
        private readonly DataContext _context;

        public ViTrisController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ViTris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViTri>>> GetViTris()
        {
          if (_context.ViTris == null)
          {
              return NotFound();
          }
            return await _context.ViTris.ToListAsync();
        }

        // GET: api/ViTris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViTri>> GetViTri(int id)
        {
          if (_context.ViTris == null)
          {
              return NotFound();
          }
            var viTri = await _context.ViTris.FindAsync(id);

            if (viTri == null)
            {
                return NotFound();
            }

            return viTri;
        }

        // PUT: api/ViTris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViTri(int id, ViTri viTri)
        {
            if (id != viTri.Id)
            {
                return BadRequest();
            }

            _context.Entry(viTri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViTriExists(id))
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

        // POST: api/ViTris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViTri>> PostViTri(ViTri viTri)
        {
          if (_context.ViTris == null)
          {
              return Problem("Entity set 'DataContext.ViTris'  is null.");
          }
            _context.ViTris.Add(viTri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViTri", new { id = viTri.Id }, viTri);
        }

        // DELETE: api/ViTris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViTri(int id)
        {
            if (_context.ViTris == null)
            {
                return NotFound();
            }
            var viTri = await _context.ViTris.FindAsync(id);
            if (viTri == null)
            {
                return NotFound();
            }

            _context.ViTris.Remove(viTri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViTriExists(int id)
        {
            return (_context.ViTris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
