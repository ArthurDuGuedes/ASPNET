using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Para fazer a ligação 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
//comando dotnet add package Microsoft.EntityFrameworkCore
//comando dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
//comando dotnet add package Microsoft.EntityFrameworkCore.Design

namespace ASPNET_ENTITY.database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Usuario> Usuarios {get; set;}
    }
}