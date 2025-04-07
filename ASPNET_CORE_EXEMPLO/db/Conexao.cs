using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace ASPNET_CORE_EXEMPLO.db
{
    public class Conexao : DbContext
    {
        public Conexao(DbContextOptions<Conexao> options) : base (options)
        {

        }

        public DbSet<Models.Maquina> Maquinas {get; set;}
        public DbSet<Models.Software> Softwares {get; set;}
        public DbSet<Models.Usuarios> Usuarios {get; set;}
    }
}