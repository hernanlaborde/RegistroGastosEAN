using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RegistroGastosEAN.DAL
{
    public class RegistroGastosContext : DbContext
    {
        public RegistroGastosContext() : base("DefaultConnection") { }

        public DbSet<RegistroGastosEAN.Models.Entidad>Entidades { get; set; }
        public DbSet<RegistroGastosEAN.Models.Responsable>Responsables { get; set; }
        public DbSet<RegistroGastosEAN.Models.Transaccion>Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}