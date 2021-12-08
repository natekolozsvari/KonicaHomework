using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KonicaHomework.Models
{
    public partial class KonicaDBContext : DbContext
    {
        public KonicaDBContext()
        {
        }

        public KonicaDBContext(DbContextOptions<KonicaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hungarian_CI_AS");

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("dokumentumok");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("extension");

                entity.Property(e => e.MainId).HasColumnName("main_id");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("source");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("esemeny");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("naplo");

                entity.Property(e => e.DokumentumId).HasColumnName("dokumentum_id");

                entity.Property(e => e.EsemenyId).HasColumnName("esemeny_id");

                entity.Property(e => e.HappenedAt).HasColumnName("happened_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
