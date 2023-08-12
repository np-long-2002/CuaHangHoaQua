using CuaHangHoaQua;
using CuaHangHoaQua.Data;
using CuaHangHoaQua.Repositories;
using CuaHangHoaQua.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Add services to the container.
AddDI(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddDI(IServiceCollection services)
{
    services.AddScoped<LoaiThucPhamRepository>();
    services.AddScoped<ILoaiThucPhamService,LoaiThucPhamService>();
    services.AddScoped<ViTriRepository>();
    services.AddScoped<IViTriService, ViTriService>();
    services.AddScoped<ThucPhamRepository>();
    services.AddScoped<IThucPhamService, ThucPhamService>();
}
