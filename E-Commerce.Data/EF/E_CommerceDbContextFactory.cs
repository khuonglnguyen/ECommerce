using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace E_Commerce.Data.EF
{
    public class E_CommerceDbContextFactory : IDesignTimeDbContextFactory<E_CommerceDbContext>
    {
        public E_CommerceDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("E_CommerceDb");

            var optionsBuilder = new DbContextOptionsBuilder<E_CommerceDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new E_CommerceDbContext(optionsBuilder.Options);
        }
    }
}
