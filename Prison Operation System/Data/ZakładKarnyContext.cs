using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Prison_Operation_System.Models;

namespace Prison_Operation_System.Data
{
    public partial class ZakładKarnyContext : DbContext
    {
        public ZakładKarnyContext()
        {
        }

        public ZakładKarnyContext(DbContextOptions<ZakładKarnyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cele> Celes { get; set; } = null!;
        public virtual DbSet<Nagrody> Nagrodies { get; set; } = null!;
        public virtual DbSet<PracaWiezniow> PracaWiezniows { get; set; } = null!;
        public virtual DbSet<Pracownicy> Pracownicies { get; set; } = null!;
        public virtual DbSet<Przestepstwa> Przestepstwas { get; set; } = null!;
        public virtual DbSet<RzeczyOsobisteWiezniow> RzeczyOsobisteWiezniows { get; set; } = null!;
        public virtual DbSet<Skrytka> Skrytkas { get; set; } = null!;
        public virtual DbSet<StopienZagrozeniaWieznium> StopienZagrozeniaWieznia { get; set; } = null!;
        public virtual DbSet<TypWidzenium> TypWidzenia { get; set; } = null!;
        public virtual DbSet<VprzedmiotyWskrytce> VprzedmiotyWskrytces { get; set; } = null!;
        public virtual DbSet<VprzestepstwaWiezniow> VprzestepstwaWiezniows { get; set; } = null!;
        public virtual DbSet<Widzenium> Widzenia { get; set; } = null!;
        public virtual DbSet<Wiezniowie> Wiezniowies { get; set; } = null!;
        public virtual DbSet<Wykroczenium> Wykroczenia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2V1OQNV;Initial Catalog=ZakładKarny;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Polish_100_CI_AS");

            modelBuilder.Entity<Cele>(entity =>
            {
                entity.ToTable("Cele");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Opis).HasMaxLength(1000);

                entity.Property(e => e.TypCeli).HasMaxLength(100);
            });

            modelBuilder.Entity<Nagrody>(entity =>
            {
                entity.ToTable("Nagrody");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Opis).HasMaxLength(500);

                entity.Property(e => e.RodzajNagrody).HasMaxLength(500);

                entity.Property(e => e.ZaCoPrzyznana).HasMaxLength(500);
            });

            modelBuilder.Entity<PracaWiezniow>(entity =>
            {
                entity.ToTable("PracaWiezniow");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RodzajPracy).HasMaxLength(500);
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.ToTable("Pracownicy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Funkcja).HasMaxLength(50);

                entity.Property(e => e.Imie).HasMaxLength(50);

                entity.Property(e => e.Nazwisko).HasMaxLength(50);

                entity.Property(e => e.Pesel)
                    .HasMaxLength(11)
                    .HasColumnName("PESEL");

                entity.Property(e => e.Stopien).HasMaxLength(50);
            });

            modelBuilder.Entity<Przestepstwa>(entity =>
            {
                entity.ToTable("Przestepstwa");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataPopelnienia).HasColumnType("date");

                entity.Property(e => e.DataWyroku).HasColumnType("date");

                entity.Property(e => e.Opis).HasMaxLength(500);

                entity.Property(e => e.RodzajPrzestepstwa).HasMaxLength(500);

                entity.Property(e => e.Wyrok).HasMaxLength(500);
            });

            modelBuilder.Entity<RzeczyOsobisteWiezniow>(entity =>
            {
                entity.ToTable("RzeczyOsobisteWiezniow");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Przedmiot).HasMaxLength(500);
            });

            modelBuilder.Entity<Skrytka>(entity =>
            {
                entity.ToTable("Skrytka");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.RzeczyOsobisteWiezniowId).HasColumnName("RzeczyOsobisteWiezniowID");

                entity.HasOne(d => d.RzeczyOsobisteWiezniow)
                    .WithMany(p => p.Skrytkas)
                    .HasForeignKey(d => d.RzeczyOsobisteWiezniowId)
                    .HasConstraintName("FK__Skrytka__RzeczyO__286302EC");
            });

            modelBuilder.Entity<StopienZagrozeniaWieznium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Opis).HasMaxLength(500);
            });

            modelBuilder.Entity<TypWidzenium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Typ).HasMaxLength(100);
            });

            modelBuilder.Entity<VprzedmiotyWskrytce>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VPrzedmiotyWSkrytce");

                entity.Property(e => e.Przedmiot).HasMaxLength(500);
            });

            modelBuilder.Entity<VprzestepstwaWiezniow>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VPrzestepstwaWiezniow");

                entity.Property(e => e.Imie).HasMaxLength(50);

                entity.Property(e => e.Nazwisko).HasMaxLength(50);

                entity.Property(e => e.Pesel)
                    .HasMaxLength(11)
                    .HasColumnName("PESEL");

                entity.Property(e => e.RodzajPrzestepstwa).HasMaxLength(500);

                entity.Property(e => e.Wyrok).HasMaxLength(500);
            });

            modelBuilder.Entity<Widzenium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.TypWidzeniaId).HasColumnName("TypWidzeniaID");

                entity.HasOne(d => d.TypWidzenia)
                    .WithMany(p => p.Widzenia)
                    .HasForeignKey(d => d.TypWidzeniaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Widzenia__TypWid__2D27B809");
            });

            modelBuilder.Entity<Wiezniowie>(entity =>
            {
                entity.ToTable("Wiezniowie");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CeleId).HasColumnName("CeleID");

                entity.Property(e => e.Imie).HasMaxLength(50);

                entity.Property(e => e.NagrodyId).HasColumnName("NagrodyID");

                entity.Property(e => e.Nazwisko).HasMaxLength(50);

                entity.Property(e => e.Pesel)
                    .HasMaxLength(11)
                    .HasColumnName("PESEL");

                entity.Property(e => e.PlanowaneZakonczenieWyroku).HasColumnType("date");

                entity.Property(e => e.PracaWiezniowId).HasColumnName("PracaWiezniowID");

                entity.Property(e => e.PrzestepstwaId).HasColumnName("PrzestepstwaID");

                entity.Property(e => e.RozpoczecieWyroku).HasColumnType("date");

                entity.Property(e => e.SkrytkaId).HasColumnName("SkrytkaID");

                entity.Property(e => e.StopienZagrozeniaWiezniaId).HasColumnName("StopienZagrozeniaWiezniaID");

                entity.Property(e => e.WidzeniaId).HasColumnName("WidzeniaID");

                entity.Property(e => e.WykroczeniaId).HasColumnName("WykroczeniaID");

                entity.HasOne(d => d.Cele)
                    .WithMany(p => p.Wiezniowies)
                    .HasForeignKey(d => d.CeleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wiezniowi__CeleI__4222D4EF");

                entity.HasOne(d => d.Nagrody)
                    .WithMany(p => p.Wiezniowies)
                    .HasForeignKey(d => d.NagrodyId)
                    .HasConstraintName("FK__Wiezniowi__Nagro__3D5E1FD2");

                entity.HasOne(d => d.PracaWiezniow)
                    .WithMany(p => p.Wiezniowies)
                    .HasForeignKey(d => d.PracaWiezniowId)
                    .HasConstraintName("FK__Wiezniowi__Praca__3F466844");

                entity.HasOne(d => d.Przestepstwa)
                    .WithMany(p => p.Wiezniowies)
                    .HasForeignKey(d => d.PrzestepstwaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wiezniowi__Przes__403A8C7D");

                entity.HasOne(d => d.Skrytka)
                    .WithMany(p => p.Wiezniowies)
                    .HasForeignKey(d => d.SkrytkaId)
                    .HasConstraintName("FK__Wiezniowi__Skryt__3B75D760");

                entity.HasOne(d => d.StopienZagrozeniaWieznia)
                    .WithMany(p => p.Wiezniowies)
                    .HasForeignKey(d => d.StopienZagrozeniaWiezniaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wiezniowi__Stopi__412EB0B6");

                entity.HasOne(d => d.Widzenia)
                    .WithMany(p => p.Wiezniowies)
                    .HasForeignKey(d => d.WidzeniaId)
                    .HasConstraintName("FK__Wiezniowi__Widze__3C69FB99");

                entity.HasOne(d => d.Wykroczenia)
                    .WithMany(p => p.Wiezniowies)
                    .HasForeignKey(d => d.WykroczeniaId)
                    .HasConstraintName("FK__Wiezniowi__Wykro__3E52440B");
            });

            modelBuilder.Entity<Wykroczenium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Kara).HasMaxLength(500);

                entity.Property(e => e.Opis).HasMaxLength(500);

                entity.Property(e => e.RodzajWykroczenia).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
