using CuaHangHoaQua.Models.RequestModels;
using CuaHangHoaQua.Models;
using CuaHangHoaQua.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CuaHangHoaQua.Models.ResponseModels;

namespace CuaHangHoaQua.Services
{
    public interface IViTriService
    {
        public Task<ICollection<ViTri>> GetViTris();
        public Task<ViTri> GetViTri(int Id);
        public Task CreateViTri(ViTriRequest loai);
        public Task UpdateViTri(int Id,ViTriResponse loai);
        public Task DeleteViTri(int Id);
    }
    public class ViTriService : IViTriService
    {
        private readonly ViTriRepository _viTriRepository;
        private readonly IMapper _mapper;
        public ViTriService(ViTriRepository viTriRepository, IMapper mapper)
        {
            _viTriRepository = viTriRepository;
            _mapper = mapper;
        }

        public Task CreateViTri(ViTriRequest loai)
        {
            var newmap = _mapper.Map<ViTri>(loai);
            var newvt = _viTriRepository.Create(newmap);
            return newvt;
        }

        public async Task DeleteViTri(int Id)
        {
            await _viTriRepository.Delete(Id);
        }

        public async Task<ViTri> GetViTri(int Id)
        {
            var vt = await _viTriRepository.GetId(Id);
            return vt;
        }

        public async Task<ICollection<ViTri>> GetViTris()
        {
            var vt = await _viTriRepository.GetAll().ToListAsync();
            return vt;
        }

        public async Task UpdateViTri(int Id, ViTriResponse loai)
        {
            if(Id == loai.Id)
            {
                var update = _mapper.Map<ViTri>(loai);
                _viTriRepository.Edit(update);
            }
        }
        
    }
}
