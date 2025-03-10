using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API2.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Escultura> Esculturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=ep-twilight-glitter-a41qm117-pooler.us-east-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_lH9kF3yfxGuz;SSL Mode=Require;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Escultura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("esculturas_pkey");

            entity.ToTable("esculturas");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Historia)
                .HasColumnType("character varying")
                .HasColumnName("historia");
            entity.Property(e => e.Imagen)
                .HasColumnType("character varying")
                .HasColumnName("imagen");
            entity.Property(e => e.NombreEscultura)
                .HasColumnType("character varying")
                .HasColumnName("nombreEscultura");
            entity.Property(e => e.Precio)
                .HasColumnType("character varying")
                .HasColumnName("precio");
            entity.Property(e => e.Vendido).HasColumnName("vendido");

            entity.Property(e => e.Ancho) // Nueva propiedad
           .HasColumnType("character varying")
           .HasColumnName("ancho");

            entity.Property(e => e.Alto) // Nueva propiedad
                .HasColumnType("character varying")
                .HasColumnName("alto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}