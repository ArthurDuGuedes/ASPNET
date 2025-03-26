using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using AtividadeAspNet1.db;

namespace AtividadeAspNet1
{
    public class Executar
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conncetionString = builder.Configuration.GetConnectionString("PostgresConnection"); 

            builder.Services.AddDbContext<Conexao>(options => options.UseNpgsql(conncetionString));

            builder.Services.AddControllers();
            

            builder .Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app	= builder.Build();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            // app.UseEndpoints(endpoint =>{
            //     endpoint.MapGet("/", async context => {
            //         context.Response.Redirect("/index.html");
            //     });
            // });
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}