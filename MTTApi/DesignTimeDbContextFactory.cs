using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MTTApi.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MTTApi
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MTTContext>
    {
        public MTTContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MTTContext>();
            var connectionString = configuration.GetConnectionString("mttDBConnectionString");
            builder.UseSqlServer(connectionString);
            return new MTTContext(builder.Options);
        }
    }
}
