namespace CuaHangHoaQua.Models
{
    public class ViTri
    {
        public int Id { get; set; }
        public string Ke { get; set; }
        public ICollection<ViTri_ThucPham> viTri_ThucPhams { get; set; }
    }
}
