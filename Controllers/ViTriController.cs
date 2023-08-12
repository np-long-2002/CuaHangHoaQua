using AutoMapper;
using CuaHangHoaQua.Models;
using CuaHangHoaQua.Models.RequestModels;
using CuaHangHoaQua.Models.ResponseModels;
using CuaHangHoaQua.Repositories;
using CuaHangHoaQua.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangHoaQua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViTriController : ControllerBase
    {
        private readonly IViTriService _viTriService;
        private readonly IMapper _mapper;
        public ViTriController(IViTriService viTriService, IMapper mapper)
        {
            _viTriService = viTriService;
            _mapper = mapper;
        }
        [HttpGet("vitri")]
        public async Task<IActionResult> GetViTris()
        {
            var vt = await _viTriService.GetViTris();
            return Ok(_mapper.Map<List<ViTriResponse>>(vt));
        }
        [HttpGet("vitri/{id}")]
        public async Task<IActionResult> GetViTri(int id)
        {
            var vt = await _viTriService.GetViTri(id);
            return Ok(_mapper.Map<ViTriResponse>(vt));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ViTriRequest vt)
        {
            await _viTriService.CreateViTri(vt);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,ViTriResponse viTriResponse)
        {
            await _viTriService.UpdateViTri(id, viTriResponse);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _viTriService.DeleteViTri(id);
            return Ok();
        }
    }
}
