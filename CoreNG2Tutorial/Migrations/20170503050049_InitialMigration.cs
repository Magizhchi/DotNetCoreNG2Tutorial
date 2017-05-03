using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreNG2Tutorial.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operations",
                columns: table => new
                {
                    operationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    operationDesc = table.Column<string>(type: "varchar(50)", nullable: false),
                    operationName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1", x => x.operationID);
                    table.ForeignKey(
                        name: "FK_operations_operations",
                        column: x => x.operationID,
                        principalTable: "operations",
                        principalColumn: "operationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    historyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    argument1 = table.Column<int>(nullable: true),
                    argument2 = table.Column<int>(nullable: true),
                    operationID = table.Column<int>(nullable: false),
                    result = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.historyID);
                    table.ForeignKey(
                        name: "FK_history_operations_operationID",
                        column: x => x.operationID,
                        principalTable: "operations",
                        principalColumn: "operationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_history_operationID",
                table: "history",
                column: "operationID");

            migrationBuilder.CreateIndex(
                name: "IX_operations_operationID",
                table: "operations",
                column: "operationID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "operations");
        }
    }
}
