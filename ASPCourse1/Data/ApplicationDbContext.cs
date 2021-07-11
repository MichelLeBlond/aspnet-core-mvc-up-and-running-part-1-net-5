using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCourse1.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPCourse1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category>Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
    }
}
