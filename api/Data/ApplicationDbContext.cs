using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){}
        
        public DbSet<api.Models.Stock> Stocks { get; set; }
        public DbSet<api.Models.Comment> Comments { get; set; }

    }
}