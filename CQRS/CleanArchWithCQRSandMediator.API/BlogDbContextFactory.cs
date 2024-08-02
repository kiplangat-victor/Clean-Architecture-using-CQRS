using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CleanArchWithCQRSandMediator.Infra
{
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            var connectionString = configuration.GetConnectionString("AppDefaultConnectionString");
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));

            return new BlogDbContext(optionsBuilder.Options);
        }
    }
}
