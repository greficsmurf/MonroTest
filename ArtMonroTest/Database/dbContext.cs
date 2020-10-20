using ArtMonroTest.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ArtMonroTest.DataBase
{
    public class dbContext : DbContext
    {
        public DbSet<TestData> Data { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=MonroArt;Username=postgres;Password=admin");
        public dbContext()
        {
        }
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }   
    }
}
