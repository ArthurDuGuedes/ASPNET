using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder; //dotnet add package Microsoft.AspNetCore.Hosting
using Microsoft.Extensions.Hosting; //dotnet add package Microsoft.Extensions.Hosting
using Microsoft.AspNetCore.Hosting; 
using System.Security.Cryptography;
using System.Net;


namespace Teste
{
    public class Teste
    {
        static void Main(string[] args)
        {
            
            var Builder = WebApplication.CreateBuilder(args);
            var app = Builder.Build();
            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoint =>{
                endpoint.MapGet("/", async context => {
                    context.Response.Redirect("/index.html");
                });
            });

            app.Run();

            
        }   

        
    }
}
