using CuaHangHoaQua.Models.RequestModels;
using CuaHangHoaQua.Models;
using CuaHangHoaQua.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CuaHangHoaQua.Models.ResponseModels;

namespace CuaHangHoaQua.Services
{
    public interface IThucPhamService
    {
        public Task<ICollection<ThucPham>> GetThucPhams();
        public Task<ThucPham> GetThucPham(int Id);
        public Task CreateThucPham(ThucPhamRequest loai);
        public Task UpdateThucPham(int Id, ThucPhamResponse thucPhamResponse);
        public Task DeleteThucPham(int Id);
    }
    public class ThucPhamService : IThucPhamService
    {
        private readonly ThucPhamRepository _thucphamRepository;
        private readonly IMapper _mapper;
        public ThucPhamService(ThucPhamRepository thucphamRepository, IMapper mapper)
        {
            _thucphamRepository = thucphamRepository;
            _mapper = mapper;
        }

        public Task CreateThucPham(ThucPhamRequest loai)
        {
            var newMap = _mapper.Map<ThucPham>(loai);
            var newtp = _thucphamRepository.Create(newMap);
            return newtp;
        }

        public async Task DeleteThucPham(int Id)
        {
            await _thucphamRepository.Delete(Id);
        }

        public async Task<ThucPham> GetThucPham(int Id)
        {
            var tp = await _thucphamRepository.GetId(Id);
            return tp;
        }

        public async Task<ICollection<ThucPham>> GetThucPhams()
        {
            var tp = await _thucphamRepository.GetAll().ToListAsync();
            return tp;
        }

        public async Task UpdateThucPham(int Id, ThucPhamResponse thucPhamResponse)
        {
            if (Id == thucPhamResponse.Id)
            {
                var update = _mapper.Map<ThucPham>(thucPhamResponse);
                _thucphamRepository.Edit(update);
            }
        }
    }
}
