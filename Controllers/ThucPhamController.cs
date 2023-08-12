using AutoMapper;
using CuaHangHoaQua.Models.RequestModels;
using CuaHangHoaQua.Models.ResponseModels;
using CuaHangHoaQua.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangHoaQua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThucPhamController : ControllerBase
    {
        private readonly IThucPhamService _thucPhamService;
        private readonly IMapper _mapper;
        public ThucPhamController(IThucPhamService thucPhamService, IMapper mapper)
        {
            _thucPhamService = thucPhamService;
            _mapper = mapper;
        }
        [HttpGet("thucpham")]
        public async Task<IActionResult> GetThucPhams()
        {
            var tp = await _thucPhamService.GetThucPhams();
            return Ok(_mapper.Map<List<ThucPhamResponse>>(tp));
        }
        [HttpGet("thucpham/{id}")]
        public async Task<IActionResult> GetThucPham(int id)
        {
            var tp = await _thucPhamService.GetThucPham(id);
            return Ok(_mapper.Map<ThucPhamResponse>(tp));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ThucPhamRequest thucPhamRequest)
        {
            await _thucPhamService.CreateThucPham(thucPhamRequest);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ThucPhamResponse thucPhamResponse)
        {
            await _thucPhamService.UpdateThucPham(id, thucPhamResponse);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _thucPhamService.DeleteThucPham(id);
            return Ok();
        }
    }
}
