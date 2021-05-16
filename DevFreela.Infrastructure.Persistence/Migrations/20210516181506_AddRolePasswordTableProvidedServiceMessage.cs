using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    public partial class AddRolePasswordTableProvidedServiceMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProvidedServiceMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IdProvidedService = table.Column<int>(nullable: false),
                    ProvidedServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidedServiceMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidedServiceMessage_ProvidedServices_ProvidedServiceId",
                        column: x => x.ProvidedServiceId,
                        principalTable: "ProvidedServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServiceMessage_ProvidedServiceId",
                table: "ProvidedServiceMessage",
                column: "ProvidedServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidedServiceMessage");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
