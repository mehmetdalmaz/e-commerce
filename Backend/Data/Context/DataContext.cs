using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext:DbContext 
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=192.168.1.31;Initial Catalog=e-CommerceDb;User ID=sa;Password=kayseri38;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True; ");
        }
    }
    
}