using EFHiLo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EFHiLo
{
    class Program
    {
        static DbContextOptions<HiLoContext> dbContextOption = new DbContextOptions<HiLoContext>();
        static DbContextOptionsBuilder<HiLoContext> dbContextOptionBuilder = new DbContextOptionsBuilder<HiLoContext>(dbContextOption);

        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsettings.Development.json", true, true)
                .Build();

            var db = new HiLoContext(dbContextOptionBuilder.UseSqlServer(config.GetConnectionString("HiLoConnection")).Options);

            db.Users.Add(new User() { Name = "Hua", CreateTime = DateTime.Now });
            db.VipUsers.Add(new VipUser() { Name = "w", CreateTime = DateTime.Now });
            db.SaveChanges();
        }
    }
}
