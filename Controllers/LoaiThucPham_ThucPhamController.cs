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
    public class LoaiThucPham_ThucPhamController : ControllerBase
    {
        private readonly DataContext _context;

        public LoaiThucPham_ThucPhamController(DataContext context)
        {
            _context = context;
        }

        // GET: api/LoaiThucPham_ThucPham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiThucPham_ThucPham>>> GetLoaiThucPham_ThucPhams()
        {
          if (_context.LoaiThucPham_ThucPhams == null)
          {
              return NotFound();
          }
            return await _context.LoaiThucPham_ThucPhams.ToListAsync();
        }

        // GET: api/LoaiThucPham_ThucPham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiThucPham_ThucPham>> GetLoaiThucPham_ThucPham(int id)
        {
          if (_context.LoaiThucPham_ThucPhams == null)
          {
              return NotFound();
          }
            var loaiThucPham_ThucPham = await _context.LoaiThucPham_ThucPhams.FindAsync(id);

            if (loaiThucPham_ThucPham == null)
            {
                return NotFound();
            }

            return loaiThucPham_ThucPham;
        }

        // PUT: api/LoaiThucPham_ThucPham/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiThucPham_ThucPham(int id, LoaiThucPham_ThucPham loaiThucPham_ThucPham)
        {
            if (id != loaiThucPham_ThucPham.LoaiThucPhamId)
            {
                return BadRequest();
            }

            _context.Entry(loaiThucPham_ThucPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiThucPham_ThucPhamExists(id))
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

        // POST: api/LoaiThucPham_ThucPham
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiThucPham_ThucPham>> PostLoaiThucPham_ThucPham(LoaiThucPham_ThucPham loaiThucPham_ThucPham)
        {
          if (_context.LoaiThucPham_ThucPhams == null)
          {
              return Problem("Entity set 'DataContext.LoaiThucPham_ThucPhams'  is null.");
          }
            _context.LoaiThucPham_ThucPhams.Add(loaiThucPham_ThucPham);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoaiThucPham_ThucPhamExists(loaiThucPham_ThucPham.LoaiThucPhamId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoaiThucPham_ThucPham", new { id = loaiThucPham_ThucPham.LoaiThucPhamId }, loaiThucPham_ThucPham);
        }

        // DELETE: api/LoaiThucPham_ThucPham/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiThucPham_ThucPham(int id)
        {
            if (_context.LoaiThucPham_ThucPhams == null)
            {
                return NotFound();
            }
            var loaiThucPham_ThucPham = await _context.LoaiThucPham_ThucPhams.FindAsync(id);
            if (loaiThucPham_ThucPham == null)
            {
                return NotFound();
            }

            _context.LoaiThucPham_ThucPhams.Remove(loaiThucPham_ThucPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaiThucPham_ThucPhamExists(int id)
        {
            return (_context.LoaiThucPham_ThucPhams?.Any(e => e.LoaiThucPhamId == id)).GetValueOrDefault();
        }
    }
}
