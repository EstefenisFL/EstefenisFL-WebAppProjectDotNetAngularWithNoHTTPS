using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebData.DbContexts
{
    public class SQLiteContextTests : DbContext
    {
        public DbSet<ClientDTO> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //<===== InMemoryDatabase used only for tests ====>
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestDataBaseAUT");

        }

        public List<ClientDTO> GetDataBase()
        {
            //lembre-se de alterar o caminho do arquivo...
            var json = File.ReadAllText("C:\\Users\\Estef\\source\\repos\\back_WebAppAPINoHttps_independent\\ProjectWebData\\DbContexts\\Base.json");
            var database = JsonConvert.DeserializeObject<List<ClientDTO>>(json);
            return database;
        }
    }
}