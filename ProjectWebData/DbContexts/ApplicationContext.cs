﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebData.DbContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<OrderDTO> Pedidos { get; set; }

        public DbSet<ClientDTO> Clients { get; set; }

        public DbSet<ItemDTO> Items { get; set; }

        //Usar esse construtor quando for obter a connection string diretamente pelo configuring do program lendo appsettings
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        //<========Usar o método abaixo OnConfiguring apenas quando não prover a connection string diretamente pelo appsettings no program ou para add migrations============>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //<===== Quando a aplicação estiver em um servidor ====>
        //    //optionsBuilder.UseSqlServer("Server = DESKTOP-3E8SV0G\\SQLEXPRESS; Database = WebApplicationDataBaseForStudy; Trusted_Connection = True; TrustServerCertificate=True;");

        //    //<===== Quando a aplicação rodar local ====>
        //    //setar string hard coded
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-3E8SV0G\\SQLEXPRESS; Initial Catalog=WebApplicationDataBaseForStudy; Trusted_Connection = True; TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //ou podemos resumir as linhas 22 a 25 na linha a seguir:
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}