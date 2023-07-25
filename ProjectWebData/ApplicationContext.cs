using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebData
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Pedidos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionBuilder.UseSqlServer("Server = DESKTOP-3E8SV0G\\SQLEXPRESS; Database = WebApplicationDataBaseForStudy; Trusted_Connection = True;");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-3E8SV0G\\SQLEXPRESS; Initial Catalog=WebApplicationDataBaseForStudy; Trusted_Connection = True;");
        }
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