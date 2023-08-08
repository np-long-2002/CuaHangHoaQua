namespace CuaHangHoaQua.Models
{
    public class LoaiThucPham
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public ICollection<LoaiThucPham_ThucPham> loaiThucPham_ThucPhams { get; set; }
    }
}
