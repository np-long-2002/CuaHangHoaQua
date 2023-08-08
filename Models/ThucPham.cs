namespace CuaHangHoaQua.Models
{
    public class ThucPham
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public ICollection<LoaiThucPham_ThucPham> loaiThucPham_ThucPhams { get; set; }
        public ICollection<ViTri_ThucPham> viTri_ThucPhams { get; set; }
    }
}
