// VotingContextFactory.cs in the Infrastructure Layer
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using voteSphere.Infrastructure.Database;

namespace voteSphere.Infrastructure
{
    public class VotingContextFactory : IDesignTimeDbContextFactory<VotingContext>
    {
        public VotingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VotingContext>();

            // Here, we use a different way to load the configuration for the migrations
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../voteSphere")) // Adjust to match your Web project path
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();


            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Use Npgsql (PostgreSQL) or any other provider for the DbContext
            optionsBuilder.UseNpgsql(connectionString); 

            return new VotingContext(optionsBuilder.Options);
        }
    }
}
