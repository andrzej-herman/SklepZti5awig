using Microsoft.EntityFrameworkCore;
using Shop.Api.Entities;
using Shop.Api.Repository;
using Shop.Api.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddDbContext<SanShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnetion"),
        assembly => assembly.MigrationsAssembly(typeof(SanShopContext).Assembly.FullName));
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
