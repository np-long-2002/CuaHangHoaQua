namespace CuaHangHoaQua.Models
{
    public class ViTri_ThucPham
    {
        public int ViTriId { get; set; }
        public int ThucPhamId { get; set; }
        public ViTri ViTri { get; set; }
        public ThucPham ThucPham { get; set; }
    }
}
