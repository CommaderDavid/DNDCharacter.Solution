using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DNDCharacter.Models
{
    public class DNDCharacterContextFactory : IDesignTimeDbContextFactory<DNDCharacterContext>
    {

        DNDCharacterContext IDesignTimeDbContextFactory<DNDCharacterContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var builder = new DbContextOptionsBuilder<DNDCharacterContext>();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new DNDCharacterContext(builder.Options);
        }
    }
}