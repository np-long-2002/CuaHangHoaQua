namespace CuaHangHoaQua.Models
{
    public class LoaiThucPham_ThucPham
    {
        public int ThucPhamId { get; set; }
        public int LoaiThucPhamId { get; set; }
        public ThucPham ThucPham { get; set; }
        public LoaiThucPham LoaiThucPham { get; set; }
    }
}
