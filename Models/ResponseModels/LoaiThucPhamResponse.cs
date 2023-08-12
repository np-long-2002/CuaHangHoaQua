namespace CuaHangHoaQua.Models.ResponseModels
{
    public class LoaiThucPhamResponse
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public List<ThucPhamResponse> thucPhamloaiResponses { get; set; }
    }
}
