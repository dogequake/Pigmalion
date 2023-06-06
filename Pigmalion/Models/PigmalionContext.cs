using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pigmalion.Models;

public partial class PigmalionContext : DbContext
{
    public PigmalionContext()
    {
    }

    public PigmalionContext(DbContextOptions<PigmalionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HOME-PC; Database=Pigmalion; Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity);

            entity.ToTable("City");

            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.Idregion).HasColumnName("idregion");
            entity.Property(e => e.NameCity)
                .HasMaxLength(50)
                .HasColumnName("name_city");

            entity.HasOne(d => d.IdregionNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.Idregion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Region");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.ToTable("Client");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Appeal)
                .HasMaxLength(50)
                .HasColumnName("appeal");
            entity.Property(e => e.DateCreation)
                .HasColumnType("datetime")
                .HasColumnName("date_creation");
            entity.Property(e => e.Idcityclient).HasColumnName("idcityclient");
            entity.Property(e => e.Idcountryclient).HasColumnName("idcountryclient");
            entity.Property(e => e.Iddirectionclient).HasColumnName("iddirectionclient");
            entity.Property(e => e.Idregionclient).HasColumnName("idregionclient");
            entity.Property(e => e.Phonenum)
                .HasMaxLength(17)
                .HasColumnName("phonenum");

            entity.HasOne(d => d.IdcityclientNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Idcityclient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_City");

            entity.HasOne(d => d.IdcountryclientNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Idcountryclient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_Country");

            entity.HasOne(d => d.IddirectionclientNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Iddirectionclient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_direction");

            entity.HasOne(d => d.IdregionclientNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Idregionclient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_Region");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry);

            entity.ToTable("Country");

            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.NameCountry)
                .HasMaxLength(50)
                .HasColumnName("name_country");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirection).HasName("PK_direction");

            entity.ToTable("Direction");

            entity.Property(e => e.IdDirection).HasColumnName("id_direction");
            entity.Property(e => e.NameDirection)
                .HasMaxLength(50)
                .HasColumnName("name_direction");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.IdRegion);

            entity.ToTable("Region");

            entity.Property(e => e.IdRegion).HasColumnName("id_region");
            entity.Property(e => e.Idcountry).HasColumnName("idcountry");
            entity.Property(e => e.NameRegion)
                .HasMaxLength(50)
                .HasColumnName("name_region");

            entity.HasOne(d => d.IdcountryNavigation).WithMany(p => p.Regions)
                .HasForeignKey(d => d.Idcountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Region_Country1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
