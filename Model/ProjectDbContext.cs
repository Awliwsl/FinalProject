using Microsoft.EntityFrameworkCore;
using Model;
using Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProjectDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FinalProjectDb;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=False");
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}

        

