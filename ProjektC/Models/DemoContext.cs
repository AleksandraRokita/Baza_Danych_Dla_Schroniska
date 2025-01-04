using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjektC.Models;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adopcja> Adopcjas { get; set; }

    public virtual DbSet<Lokacja> Lokacjas { get; set; }

    public virtual DbSet<Pracownik> Pracowniks { get; set; }

    public virtual DbSet<Uzytkownik> Uzytkowniks { get; set; }

    public virtual DbSet<Zwierze> Zwierzes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Schronisko;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adopcja>(entity =>
        {
            entity.HasKey(e => e.IdAdopcji).HasName("PK__Adopcja__49CC5FD77D412F96");

            entity.Property(e => e.StatusAdopcji).IsFixedLength();

            entity.HasOne(d => d.IdPracownikaNavigation).WithMany(p => p.Adopcjas).HasConstraintName("FK__Adopcja__id_prac__4222D4EF");

            entity.HasOne(d => d.IdUzytkownikaNavigation).WithMany(p => p.Adopcjas).HasConstraintName("FK__Adopcja__id_uzyt__412EB0B6");

            entity.HasOne(d => d.IdZwierzeciaNavigation).WithMany(p => p.Adopcjas).HasConstraintName("FK__Adopcja__id_zwie__403A8C7D");
        });

        modelBuilder.Entity<Lokacja>(entity =>
        {
            entity.HasKey(e => e.IdLokacji).HasName("PK__Lokacja__CBEF479F7E87430F");

            entity.Property(e => e.Lokacja1).IsFixedLength();
        });

        modelBuilder.Entity<Pracownik>(entity =>
        {
            entity.HasKey(e => e.IdPracownika).HasName("PK__Pracowni__5D8E25F22A0A0CB1");
        });

        modelBuilder.Entity<Uzytkownik>(entity =>
        {
            entity.HasKey(e => e.IdUzytkownika).HasName("PK__Uzytkown__4B7A7301314DCA07");

            entity.Property(e => e.Imie).IsFixedLength();
            entity.Property(e => e.Nazwisko).IsFixedLength();
        });

        modelBuilder.Entity<Zwierze>(entity =>
        {
            entity.HasKey(e => e.IdZwierzecia).HasName("PK__Zwierze__4F39CD469FA6C205");

            entity.Property(e => e.Gatunek).IsFixedLength();
            entity.Property(e => e.Imie).IsFixedLength();
            entity.Property(e => e.Rasa).IsFixedLength();

            entity.HasOne(d => d.IdLokacjiNavigation).WithMany(p => p.Zwierzes).HasConstraintName("FK_Zwierze_Lokacja");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
