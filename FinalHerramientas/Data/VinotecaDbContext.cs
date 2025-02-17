﻿using FinalHerramientas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinalHerramientas.Data
{
    public class VinotecaDbContext : IdentityDbContext
    {
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Vino> Vinos { get; set; }
        public DbSet<Despacho> Despachos { get; set; }
        public DbSet<DetalleDespacho> DetalleDespachos { get; set; }
        public VinotecaDbContext(DbContextOptions<VinotecaDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodega>()
                .HasMany(b => b.Vinos)
                .WithOne(v => v.Bodega)
                .HasForeignKey(v => v.BodegaID);

            modelBuilder.Entity<Vino>()
                .HasMany(v => v.DetalleDespachos)
                .WithOne(dd => dd.Vino)
                .HasForeignKey(dd => dd.Id);

            modelBuilder.Entity<Despacho>()
                .HasMany(d => d.DetalleDespachos)
                .WithOne(dd => dd.Despacho)
                .HasForeignKey(dd => dd.Id);
            base.OnModelCreating(modelBuilder);

        }
    }
}
