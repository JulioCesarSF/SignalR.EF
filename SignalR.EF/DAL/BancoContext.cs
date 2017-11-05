using SignalR.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SignalR.EF.DAL
{
    public class BancoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public BancoContext()
        {

        }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}