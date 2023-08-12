namespace CuaHangHoaQua.Models.ResponseModels
{
    public class ViTriResponse
    {
        public int Id { get; set; }
        public string Ke { get; set; }
        public List<ThucPhamResponse> thucPhamvitriResponses { get; set; }
    }
}
