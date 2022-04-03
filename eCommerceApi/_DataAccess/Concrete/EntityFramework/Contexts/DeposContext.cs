using System;
using System.Collections.Generic;
using System.Text;
using _Core.Utilities.Result;
using _DataAccess.Constants;
using _Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace _DataAccess.Concrete.EntityFramework.Contexts
{
    public class DeposContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ProjectConfigConst.DEPOS_SQL_DB_CONNECTION_STRING);
        }

      
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Campaign> Campaings { get; set; }
        
        //  public DbSet<BookMoveDetail> BookMoveDetails { get; set; }


    }
}
