using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreNG2Tutorial.Models;

namespace CoreNG2Tutorial.Migrations
{
    [DbContext(typeof(NG2TutorialContext))]
    [Migration("20170503050049_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreNG2Tutorial.Models.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("historyID");

                    b.Property<int?>("Argument1")
                        .HasColumnName("argument1");

                    b.Property<int?>("Argument2")
                        .HasColumnName("argument2");

                    b.Property<int>("OperationId")
                        .HasColumnName("operationID");

                    b.Property<int?>("Result")
                        .HasColumnName("result");

                    b.HasKey("HistoryId");

                    b.HasIndex("OperationId");

                    b.ToTable("history");
                });

            modelBuilder.Entity("CoreNG2Tutorial.Models.Operations", b =>
                {
                    b.Property<int>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("operationID");

                    b.Property<string>("OperationDesc")
                        .IsRequired()
                        .HasColumnName("operationDesc")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OperationName")
                        .IsRequired()
                        .HasColumnName("operationName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("OperationId")
                        .HasName("PK_Table_1");

                    b.HasIndex("OperationId")
                        .IsUnique();

                    b.ToTable("operations");
                });

            modelBuilder.Entity("CoreNG2Tutorial.Models.History", b =>
                {
                    b.HasOne("CoreNG2Tutorial.Models.Operations", "Operation")
                        .WithMany("History")
                        .HasForeignKey("OperationId");
                });

            modelBuilder.Entity("CoreNG2Tutorial.Models.Operations", b =>
                {
                    b.HasOne("CoreNG2Tutorial.Models.Operations", "Operation")
                        .WithOne("InverseOperation")
                        .HasForeignKey("CoreNG2Tutorial.Models.Operations", "OperationId")
                        .HasConstraintName("FK_operations_operations");
                });
        }
    }
}
