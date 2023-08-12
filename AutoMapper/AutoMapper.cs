using AutoMapper;
using CuaHangHoaQua.Models;
using CuaHangHoaQua.Models.RequestModels;
using CuaHangHoaQua.Models.ResponseModels;
using CuaHangHoaQua.Repositories;

namespace CuaHangHoaQua.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            MapLoaiThucPham();
            MapViTri();
            MapThucPham();
        }
        private void MapLoaiThucPham()
        {
            CreateMap<LoaiThucPham, LoaiThucPhamResponse>().ReverseMap();
            CreateMap<LoaiThucPhamRequest,LoaiThucPham>().ReverseMap();
        }
        private void MapViTri()
        {
            CreateMap<ViTri, ViTriResponse>().ReverseMap();
            CreateMap<ViTriRequest,ViTri>().ReverseMap();
        }
        private void MapThucPham()
        {
            CreateMap<ThucPham,ThucPhamResponse>().ReverseMap();
            CreateMap<ThucPhamRequest, ThucPham>().ReverseMap();
        }
    }
}
