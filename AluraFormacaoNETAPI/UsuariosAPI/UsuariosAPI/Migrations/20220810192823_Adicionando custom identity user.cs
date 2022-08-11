using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "3e892f10-0158-4aef-88f6-137aa0595383");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a9b8ee1a-2b49-4ae4-8ba4-6a4983156bf0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31bfded9-93e5-4341-b209-6ed4e0cfb967", "AQAAAAEAACcQAAAAECReQnfChtOtjjT9EJu3C49MsFnRvM2Vs+IfefoVacD7Y/c8cTs1vkAbJiT3cDuMkg==", "a1f6b4d3-43f8-458b-8830-311927a18e6f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "6e420872-3ed8-426b-9ee9-89e39ac47f70");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "b19a6f5c-39aa-4ee1-b598-6a20fd5d8f10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90833d2d-ea29-4f4d-9408-777ee4671121", "AQAAAAEAACcQAAAAEEsrv5F0rp8wrxTL3XIgM3xiVzgEEzbRy89FfH8jF+IzS+/56vqF45ebW6Q6UcUyvQ==", "a85018f5-bb2f-4d09-98d9-048285aa9845" });
        }
    }
}
