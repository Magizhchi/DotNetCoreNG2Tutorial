using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreNG2Tutorial.Models
{
    public partial class NG2TutorialContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=NG2Tutorial;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.Property(e => e.HistoryId).HasColumnName("historyID");

                entity.Property(e => e.Argument1).HasColumnName("argument1");

                entity.Property(e => e.Argument2).HasColumnName("argument2");

                entity.Property(e => e.OperationId).HasColumnName("operationID");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_history_history");
            });

            modelBuilder.Entity<Operations>(entity =>
            {
                entity.HasKey(e => e.OperationId)
                    .HasName("PK_Table_1");

                entity.ToTable("operations");

                entity.Property(e => e.OperationId)
                    .HasColumnName("operationID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OperationDesc)
                    .IsRequired()
                    .HasColumnName("operationDesc")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OperationName)
                    .IsRequired()
                    .HasColumnName("operationName")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Operation)
                    .WithOne(p => p.InverseOperation)
                    .HasForeignKey<Operations>(d => d.OperationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_operations_operations");
            });
        }

        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Operations> Operations { get; set; }
    }
}