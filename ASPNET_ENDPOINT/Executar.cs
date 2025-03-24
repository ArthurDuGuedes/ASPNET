using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.Hosting; 

using Microsoft.Extensions.DependencyInjection;
//Vamos usar a ferramenta Swagger para gerar a documentação da API
//comando dotnet add package Swashbuckle.AspNetCore

namespace ASPNET_ENDPOINT
{
    public class Executar
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build(); // vai construir a aplicação
            app.UseSwagger(); // Vai usar o Swagger 
            app.UseSwaggerUI(); // Vai usar o Swagger UI
            app.UseHttpsRedirection();// Vai usar o HTTPS adicionar o middleware de redirecionamento HTTPS.
            app.UseAuthorization(); // Vai usar a autorização, adicionar o middleware de autorização.
            app.MapControllers(); //Var mapear os controladores, adicionar o middleware de mapeamento de controladores.


            app.Run();

            //caminho de swagger vai ser http://localhost:5000/swagger
        }
    }
}