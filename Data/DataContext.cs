using CuaHangHoaQua.Models;
using Microsoft.EntityFrameworkCore;

namespace CuaHangHoaQua.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }
        #region DbSet
        public DbSet<LoaiThucPham> LoaiThucPhams { get; set; }
        public DbSet<ViTri> ViTris { get; set; }
        public DbSet<ThucPham> ThucPhams { get; set; }
        public DbSet<LoaiThucPham_ThucPham> LoaiThucPham_ThucPhams { get; set; }
        public DbSet<ViTri_ThucPham> ViTri_ThucPhams { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //LoaiThucPham voi Thuc Pham
            modelBuilder.Entity<LoaiThucPham_ThucPham>()
                .HasKey(tp => new {tp.LoaiThucPhamId,tp.ThucPhamId});
            modelBuilder.Entity<LoaiThucPham_ThucPham>()
                .HasOne(p => p.ThucPham)
                .WithMany(p => p.loaiThucPham_ThucPhams)
                .HasForeignKey(p => p.ThucPhamId);
            modelBuilder.Entity<LoaiThucPham_ThucPham>()
               .HasOne(p => p.LoaiThucPham)
               .WithMany(p => p.loaiThucPham_ThucPhams)
               .HasForeignKey(p => p.LoaiThucPhamId);
            //ViTri voi Thuc Pham
            modelBuilder.Entity<ViTri_ThucPham>()
                .HasKey(vt => new { vt.ViTriId, vt.ThucPhamId });
            modelBuilder.Entity<ViTri_ThucPham>()
                .HasOne(p => p.ThucPham)
                .WithMany(p => p.viTri_ThucPhams)
                .HasForeignKey(p => p.ThucPhamId);
            modelBuilder.Entity<ViTri_ThucPham>()
                .HasOne(p => p.ViTri)
                .WithMany(p => p.viTri_ThucPhams)
                .HasForeignKey(p => p.ViTriId);

        }
    }
}
