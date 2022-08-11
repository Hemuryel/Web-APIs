using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "b19a6f5c-39aa-4ee1-b598-6a20fd5d8f10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "6e420872-3ed8-426b-9ee9-89e39ac47f70", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90833d2d-ea29-4f4d-9408-777ee4671121", "AQAAAAEAACcQAAAAEEsrv5F0rp8wrxTL3XIgM3xiVzgEEzbRy89FfH8jF+IzS+/56vqF45ebW6Q6UcUyvQ==", "a85018f5-bb2f-4d09-98d9-048285aa9845" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "25d0c977-a2b5-4249-8977-27db99775236");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51646c00-f2dc-4e61-866c-d1a39cddd41d", "AQAAAAEAACcQAAAAEGdwDxC5LQfVhZvXEdfX9BNzvGxGIce6reP69BSX1Gds7ikoZcNTSkJOiUx17V5IRw==", "52627d46-09de-4b80-adba-44470b6328f2" });
        }
    }
}
