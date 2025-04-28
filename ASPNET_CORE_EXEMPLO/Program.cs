using ASPNET_CORE_EXEMPLO.db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddControllersWithViews();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Conexao>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});

var app = builder.Build(); 
if(app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
    app.UseHttpsRedirection(); 
    app.UseAuthorization();
}

app.UseDefaultFiles(); 
app.UseStaticFiles(); 
app.UseHttpsRedirection();
app.MapControllers(); 
app.Run(); 