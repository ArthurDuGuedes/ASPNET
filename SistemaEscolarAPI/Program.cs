using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using SistemaEscolarAPI.DB;
using SistemaEscolarAPI.Models;
using SistemaEscolarAPI.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;  


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(); 
builder.Services.AddAuthorization(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;
var secret = Configuration["JwtSettings:SecretKey"];
var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    { 
        IssuerSigningKey = Key,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();

app.MapGet("/", context =>{
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;

});

app.MapControllers();
app.Run();
