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
        public virtual DbSet<Form4> Form4s { get; set; }
        public virtual DbSet<Form5> Form5s { get; set; }

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

                entity.Property(e => e.Id2)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id2");
            });

            modelBuilder.Entity<Form4>(entity =>
            {
                entity.ToTable("Form4");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.C21a).HasColumnName("_c21a");

                entity.Property(e => e.C21b).HasColumnName("_c21b");

                entity.Property(e => e.C21c).HasColumnName("_c21c");

                entity.Property(e => e.C21d).HasColumnName("_c21d");

                entity.Property(e => e.C21e).HasColumnName("_c21e");

                entity.Property(e => e.C21f).HasColumnName("_c21f");

                entity.Property(e => e.C21g).HasColumnName("_c21g");

                entity.Property(e => e.C21h).HasColumnName("_c21h");

                entity.Property(e => e.C21i).HasColumnName("_c21i");

                entity.Property(e => e.C21j).HasColumnName("_c21j");

                entity.Property(e => e.C21k).HasColumnName("_c21k");

                entity.Property(e => e.C21l).HasColumnName("_c21l");

                entity.Property(e => e.C21m).HasColumnName("_c21m");

                entity.Property(e => e.C21n).HasColumnName("_c21n");

                entity.Property(e => e.C22a).HasColumnName("_c22a");

                entity.Property(e => e.C22b).HasColumnName("_c22b");

                entity.Property(e => e.C22c).HasColumnName("_c22c");

                entity.Property(e => e.C22d).HasColumnName("_c22d");

                entity.Property(e => e.C22e).HasColumnName("_c22e");

                entity.Property(e => e.C22f).HasColumnName("_c22f");

                entity.Property(e => e.C22g).HasColumnName("_c22g");

                entity.Property(e => e.C23a).HasColumnName("_c23a");

                entity.Property(e => e.C23b).HasColumnName("_c23b");

                entity.Property(e => e.C23c).HasColumnName("_c23c");

                entity.Property(e => e.C23d).HasColumnName("_c23d");

                entity.Property(e => e.C23e).HasColumnName("_c23e");

                entity.Property(e => e.C23f).HasColumnName("_c23f");

                entity.Property(e => e.C23g).HasColumnName("_c23g");

                entity.Property(e => e.C24a).HasColumnName("_c24a");

                entity.Property(e => e.C24b).HasColumnName("_c24b");

                entity.Property(e => e.C24c).HasColumnName("_c24c");

                entity.Property(e => e.C24d).HasColumnName("_c24d");

                entity.Property(e => e.C24e).HasColumnName("_c24e");

                entity.Property(e => e.C24f).HasColumnName("_c24f");

                entity.Property(e => e.W21).HasColumnName("_w21");

                entity.Property(e => e.W22).HasColumnName("_w22");

                entity.Property(e => e.W23).HasColumnName("_w23");

                entity.Property(e => e.W24a).HasColumnName("_w24a");

                entity.Property(e => e.W24b).HasColumnName("_w24b");

                entity.Property(e => e.W24c).HasColumnName("_w24c");

                entity.Property(e => e.W24d).HasColumnName("_w24d");

                entity.Property(e => e.W25).HasColumnName("_w25");

                entity.Property(e => e.W26).HasColumnName("_w26");

                entity.Property(e => e.W27).HasColumnName("_w27");

                entity.Property(e => e.W28).HasColumnName("_w28");

                entity.Property(e => e.W29)
                    .HasMaxLength(30)
                    .HasColumnName("_w29");

                entity.Property(e => e._1a).HasMaxLength(30);

                entity.Property(e => e._1b).HasMaxLength(50);

                entity.Property(e => e._1c).HasMaxLength(30);

                entity.Property(e => e._3a).HasMaxLength(30);

                entity.Property(e => e._3b).HasMaxLength(30);

                entity.Property(e => e._3c).HasMaxLength(30);

                entity.Property(e => e._3d).HasMaxLength(30);

                entity.Property(e => e._3e).HasMaxLength(30);

                entity.Property(e => e._3f).HasMaxLength(30);

                entity.Property(e => e._3g).HasMaxLength(30);
            });

            modelBuilder.Entity<Form5>(entity =>
            {
                entity.ToTable("Form5");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.C21a).HasColumnName("_c21a");

                entity.Property(e => e.C21b).HasColumnName("_c21b");

                entity.Property(e => e.C21c).HasColumnName("_c21c");

                entity.Property(e => e.C21d).HasColumnName("_c21d");

                entity.Property(e => e.C21e).HasColumnName("_c21e");

                entity.Property(e => e.C21f).HasColumnName("_c21f");

                entity.Property(e => e.C21g).HasColumnName("_c21g");

                entity.Property(e => e.C21h).HasColumnName("_c21h");

                entity.Property(e => e.C21i).HasColumnName("_c21i");

                entity.Property(e => e.C21j).HasColumnName("_c21j");

                entity.Property(e => e.C21k).HasColumnName("_c21k");

                entity.Property(e => e.C21l).HasColumnName("_c21l");

                entity.Property(e => e.C21m).HasColumnName("_c21m");

                entity.Property(e => e.C21n).HasColumnName("_c21n");

                entity.Property(e => e.C22a).HasColumnName("_c22a");

                entity.Property(e => e.C22b).HasColumnName("_c22b");

                entity.Property(e => e.C22c).HasColumnName("_c22c");

                entity.Property(e => e.C22d).HasColumnName("_c22d");

                entity.Property(e => e.C22e).HasColumnName("_c22e");

                entity.Property(e => e.C22f).HasColumnName("_c22f");

                entity.Property(e => e.C22g).HasColumnName("_c22g");

                entity.Property(e => e.C23a).HasColumnName("_c23a");

                entity.Property(e => e.C23b).HasColumnName("_c23b");

                entity.Property(e => e.C23c).HasColumnName("_c23c");

                entity.Property(e => e.C23d).HasColumnName("_c23d");

                entity.Property(e => e.C23e).HasColumnName("_c23e");

                entity.Property(e => e.C23f).HasColumnName("_c23f");

                entity.Property(e => e.C23g).HasColumnName("_c23g");

                entity.Property(e => e.C24a).HasColumnName("_c24a");

                entity.Property(e => e.C24b).HasColumnName("_c24b");

                entity.Property(e => e.C24c).HasColumnName("_c24c");

                entity.Property(e => e.C24d).HasColumnName("_c24d");

                entity.Property(e => e.C24e).HasColumnName("_c24e");

                entity.Property(e => e.C24f).HasColumnName("_c24f");

                entity.Property(e => e.W21).HasColumnName("_w21");

                entity.Property(e => e.W22).HasColumnName("_w22");

                entity.Property(e => e.W23).HasColumnName("_w23");

                entity.Property(e => e.W24a).HasColumnName("_w24a");

                entity.Property(e => e.W24b).HasColumnName("_w24b");

                entity.Property(e => e.W24c).HasColumnName("_w24c");

                entity.Property(e => e.W24d).HasColumnName("_w24d");

                entity.Property(e => e.W25).HasColumnName("_w25");

                entity.Property(e => e.W26).HasColumnName("_w26");

                entity.Property(e => e.W27).HasColumnName("_w27");

                entity.Property(e => e.W28).HasColumnName("_w28");

                entity.Property(e => e.W29)
                    .HasMaxLength(30)
                    .HasColumnName("_w29");

                entity.Property(e => e._1a).HasMaxLength(30);

                entity.Property(e => e._1b).HasMaxLength(50);

                entity.Property(e => e._1c).HasMaxLength(30);

                entity.Property(e => e._1d).HasMaxLength(30);

                entity.Property(e => e._1e).HasMaxLength(30);

                entity.Property(e => e._3a).HasMaxLength(30);

                entity.Property(e => e._3b).HasMaxLength(30);

                entity.Property(e => e._3c).HasMaxLength(30);

                entity.Property(e => e._3d).HasMaxLength(30);

                entity.Property(e => e._3e).HasMaxLength(30);

                entity.Property(e => e._3f).HasMaxLength(30);

                entity.Property(e => e._3g).HasMaxLength(30);

                entity.Property(e => e._4a).HasMaxLength(30);

                entity.Property(e => e._4b).HasMaxLength(30);

                entity.Property(e => e._4c).HasMaxLength(30);

                entity.Property(e => e._4d).HasMaxLength(30);

                entity.Property(e => e._4e).HasMaxLength(30);

                entity.Property(e => e._4f).HasMaxLength(30);

                entity.Property(e => e._4g).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
