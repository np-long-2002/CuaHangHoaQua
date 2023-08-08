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
    public class LoaiThucPhamsController : ControllerBase
    {
        private readonly DataContext _context;

        public LoaiThucPhamsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/LoaiThucPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiThucPham>>> GetLoaiThucPhams()
        {
          if (_context.LoaiThucPhams == null)
          {
              return NotFound();
          }
            return await _context.LoaiThucPhams.ToListAsync();
        }

        // GET: api/LoaiThucPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiThucPham>> GetLoaiThucPham(int id)
        {
          if (_context.LoaiThucPhams == null)
          {
              return NotFound();
          }
            var loaiThucPham = await _context.LoaiThucPhams.FindAsync(id);

            if (loaiThucPham == null)
            {
                return NotFound();
            }

            return loaiThucPham;
        }

        // PUT: api/LoaiThucPhams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiThucPham(int id, LoaiThucPham loaiThucPham)
        {
            if (id != loaiThucPham.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaiThucPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiThucPhamExists(id))
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

        // POST: api/LoaiThucPhams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiThucPham>> PostLoaiThucPham(LoaiThucPham loaiThucPham)
        {
          if (_context.LoaiThucPhams == null)
          {
              return Problem("Entity set 'DataContext.LoaiThucPhams'  is null.");
          }
            _context.LoaiThucPhams.Add(loaiThucPham);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiThucPham", new { id = loaiThucPham.Id }, loaiThucPham);
        }

        // DELETE: api/LoaiThucPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiThucPham(int id)
        {
            if (_context.LoaiThucPhams == null)
            {
                return NotFound();
            }
            var loaiThucPham = await _context.LoaiThucPhams.FindAsync(id);
            if (loaiThucPham == null)
            {
                return NotFound();
            }

            _context.LoaiThucPhams.Remove(loaiThucPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaiThucPhamExists(int id)
        {
            return (_context.LoaiThucPhams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
