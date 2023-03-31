using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestAcuDatabase.SqlServer
{
    public partial class DBTestAcuContext : DbContext
    {
        public DBTestAcuContext()
        {
        }

        public DBTestAcuContext(DbContextOptions<DBTestAcuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TestAcu1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS_KS_WS");

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
