using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataLayer.Migrations.Blog
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blog");

            migrationBuilder.CreateTable(
                name: "batchjob",
                schema: "blog",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    classname = table.Column<string>(type: "text", nullable: true),
                    contractname = table.Column<string>(type: "text", nullable: true),
                    contractjson = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    startedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    stoppedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_batchjob", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_batchjob_status",
                schema: "blog",
                table: "batchjob",
                column: "status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "batchjob",
                schema: "blog");
        }
    }
}
