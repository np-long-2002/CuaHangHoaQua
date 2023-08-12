using AutoMapper;
using CuaHangHoaQua.Models;
using CuaHangHoaQua.Models.RequestModels;
using CuaHangHoaQua.Models.ResponseModels;
using CuaHangHoaQua.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangHoaQua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiThucPhamController : ControllerBase
    {
        private readonly ILoaiThucPhamService _loaiThucPhamService;
        private readonly IMapper _mapper;
        public LoaiThucPhamController(ILoaiThucPhamService loaiThucPhamService, IMapper mapper)
        {
            _loaiThucPhamService = loaiThucPhamService;
            _mapper = mapper;
        }
        [HttpGet("loaithucpham")]
        public async Task<IActionResult> GetLoais()
        {
            var loai = await _loaiThucPhamService.GetLoais();
            return Ok(_mapper.Map<List<LoaiThucPhamResponse>>(loai));
        }
        [HttpGet("loaithucpham/{id}")]
        public async Task<IActionResult> GetLoaiId(int id)
        {
            var loai = await _loaiThucPhamService.GetLoai(id);
            return Ok(_mapper.Map<LoaiThucPhamResponse>(loai));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoaiThucPhamRequest loaiThucPham)
        {
            await _loaiThucPhamService.CreateLoai(loaiThucPham);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LoaiThucPhamResponse loaiThucPhamResponse)
        {
            await _loaiThucPhamService.UpdateLoai(id, loaiThucPhamResponse);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _loaiThucPhamService.DeleteLoai(id);
            return Ok();
        }
    }
}
