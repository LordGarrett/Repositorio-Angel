using Proyecto_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_Final.DAL
{
    public class TiendaComputadorasContext : DbContext
    {
        public TiendaComputadorasContext() : base("TiendaComputadorasContext")
        {
         
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<Componentes> Componentes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Proyecto_Final.Models.Factura> Facturas { get; set; }
    }
}