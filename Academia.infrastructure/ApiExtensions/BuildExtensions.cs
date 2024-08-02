using Academia.infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Academia.WebApi.ApiExtensions
{
    public static class BuildExtensions
    {
        public static void AddDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var ConnectionString = optionsBuilder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(ConnectionString));
        }
    }
}
