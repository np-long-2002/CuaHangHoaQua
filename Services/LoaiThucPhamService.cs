using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using CuaHangHoaQua.Models;
using CuaHangHoaQua.Repositories;
using CuaHangHoaQua.Models.RequestModels;
using CuaHangHoaQua.Models.ResponseModels;

namespace CuaHangHoaQua.Services
{
    public interface ILoaiThucPhamService
    {
        public Task<ICollection<LoaiThucPham>> GetLoais();
        public Task<LoaiThucPham> GetLoai(int Id);
        public Task CreateLoai(LoaiThucPhamRequest loai);
        public Task UpdateLoai(int Id,LoaiThucPhamResponse loai);
        public Task DeleteLoai(int Id);
    }
    public class LoaiThucPhamService : ILoaiThucPhamService
    {
        private readonly LoaiThucPhamRepository _loaiThucPhamRepository;
        private readonly IMapper _mapper;
        public LoaiThucPhamService(LoaiThucPhamRepository loaiThucPhamRepository, IMapper mapper)
        {
            _loaiThucPhamRepository = loaiThucPhamRepository;
            _mapper = mapper;
        }


        public async Task CreateLoai(LoaiThucPhamRequest loai)
        {
            var newMap = _mapper.Map<LoaiThucPham>(loai);
            var newLoai = _loaiThucPhamRepository.Create(newMap);
        }

        public async Task DeleteLoai(int Id)
        {
            await _loaiThucPhamRepository.Delete(Id);
        }

        public async Task<LoaiThucPham> GetLoai(int Id)
        {
            var loai = await _loaiThucPhamRepository.GetId(Id);
            return loai;
        }

        public async Task<ICollection<LoaiThucPham>> GetLoais()
        {
            var loai = await _loaiThucPhamRepository.GetAll().ToListAsync();
            return loai;
        }

        public async Task UpdateLoai(int Id, LoaiThucPhamResponse loai)
        {
            if (Id == loai.Id)
            {
                var update = _mapper.Map<LoaiThucPham>(loai);
                _loaiThucPhamRepository.Edit(update);
            }
        }
    }
}
