using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextureMarket.Migrations
{
    /// <inheritdoc />
    public partial class modifying_Texture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Textures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Lacunarity",
                table: "Textures",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NoiseType",
                table: "Textures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Octaves",
                table: "Textures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Persistence",
                table: "Textures",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Scale",
                table: "Textures",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Seed",
                table: "Textures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Textures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Textures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Height", "Lacunarity", "NoiseType", "Octaves", "Persistence", "Scale", "Seed", "Width" },
                values: new object[] { 0, 0f, 0, 0, 0f, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Textures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Height", "Lacunarity", "NoiseType", "Octaves", "Persistence", "Scale", "Seed", "Width" },
                values: new object[] { 0, 0f, 0, 0, 0f, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Textures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Height", "Lacunarity", "NoiseType", "Octaves", "Persistence", "Scale", "Seed", "Width" },
                values: new object[] { 0, 0f, 0, 0, 0f, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Textures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Height", "Lacunarity", "NoiseType", "Octaves", "Persistence", "Scale", "Seed", "Width" },
                values: new object[] { 0, 0f, 0, 0, 0f, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Textures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Height", "Lacunarity", "NoiseType", "Octaves", "Persistence", "Scale", "Seed", "Width" },
                values: new object[] { 0, 0f, 0, 0, 0f, 0f, 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Textures");

            migrationBuilder.DropColumn(
                name: "Lacunarity",
                table: "Textures");

            migrationBuilder.DropColumn(
                name: "NoiseType",
                table: "Textures");

            migrationBuilder.DropColumn(
                name: "Octaves",
                table: "Textures");

            migrationBuilder.DropColumn(
                name: "Persistence",
                table: "Textures");

            migrationBuilder.DropColumn(
                name: "Scale",
                table: "Textures");

            migrationBuilder.DropColumn(
                name: "Seed",
                table: "Textures");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Textures");
        }
    }
}
