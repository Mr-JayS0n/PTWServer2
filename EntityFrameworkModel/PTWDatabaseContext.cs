using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PTWServer1
{
    public partial class PTWDatabaseContext : DbContext
    {
        public PTWDatabaseContext(DbContextOptions<PTWDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Form2> Form2s { get; set; }
        public virtual DbSet<Form3> Form3s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);initial catalog=PTWDatabase;trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.ToTable("connections");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.SignalrId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("signalrId");

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timeStamp");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Form");

                entity.Property(e => e.FormDate).HasColumnType("datetime");

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Form2>(entity =>
            {
                entity.ToTable("Form2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(22);
            });

            modelBuilder.Entity<Form3>(entity =>
            {
                entity.ToTable("Form3");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.FormName)
                    .HasMaxLength(50)
                    .HasColumnName("formName");

                entity.Property(e => e.Formdate)
                    .HasColumnType("datetime")
                    .HasColumnName("formdate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
