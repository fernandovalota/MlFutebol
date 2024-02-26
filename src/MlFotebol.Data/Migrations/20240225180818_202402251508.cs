using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MlFutebol.Data.Migrations
{
    /// <inheritdoc />
    public partial class _202402251508 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("010fbbf9-051b-46f0-a1a2-a7a0065cfe6b"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("18cae2c1-ab64-49cc-a221-418b2ff86d97"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("b0bd8fb1-9fa0-4d73-a33c-b3a59ef7e2d4"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("e208df1e-45cd-45ef-9862-6f0f940fd49c"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("11d80853-27bb-480f-ac27-f798ba328a05"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("4fcc5b79-5e98-44c8-84d7-ed6f1e2b3c15"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("5a6d80a6-3779-4a48-b97b-f7dbde4ad2af"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("854d5cc6-091f-4f44-9982-cb74b2f7d35f"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("9b49f7dd-7a3b-4559-960c-cab9f07086b3"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("bba324d3-fe29-48f0-9f50-e70e8a2748dd"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("e4807816-282c-41d0-a0b3-9f03c1560323"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("f0c122f8-0d5d-480e-82e0-402d3c75633b"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("f5196ad1-29d0-4d30-8e39-95a69a8ec6f3"));

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "Id", "Nome", "Pontos" },
                values: new object[,]
                {
                    { new Guid("50dd42ca-1585-4105-81a8-032bbcef0cf1"), "Gatorade", 2 },
                    { new Guid("b6fd50f6-8b0a-44cb-9c3e-b39fcf3d5526"), "Chuteira", 4 },
                    { new Guid("c007911c-e13d-45b3-8437-4954eca65973"), "Camisa", 1 },
                    { new Guid("d8e00bc4-1a1b-40f0-9080-1cca0c9ef5b5"), "Caneleira", 3 }
                });

            migrationBuilder.InsertData(
                table: "Posicoes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("17697393-9f7e-490d-b6d7-f252617d59de"), "Meia - Atacante" },
                    { new Guid("1a85f056-9886-4400-9225-4061868dc77f"), "Lateral Esquerda" },
                    { new Guid("51dd9d2f-3fd2-40d1-a5d1-a550ee478139"), "Lateral Direita" },
                    { new Guid("559a4868-0998-4aef-9bdc-a0bb03c18092"), "Meia" },
                    { new Guid("7a558ec4-2b9a-4cb8-8284-79ef569e498c"), "Centro Avante" },
                    { new Guid("84a0fe7f-7721-4a89-b39f-d19ae7cedfd4"), "Goleiro" },
                    { new Guid("8dbb9861-0d50-496b-92a4-72cf652b3c3d"), "Zagueiro" },
                    { new Guid("a774626b-a57b-4e07-9c86-a89bb47e6f68"), "Volante" },
                    { new Guid("cacf7b1c-ec85-464b-9f89-65e7d30d9135"), "Atacante" }
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "Nome", "Serie" },
                values: new object[,]
                {
                    { new Guid("4c005e2a-72d9-4dab-b849-75b3fc9ee61c"), "Gremio Prudente", "B" },
                    { new Guid("67c1c3cd-cbc3-4972-8e25-4e113cd03b17"), "Corinthians", "A" },
                    { new Guid("73d44936-6042-4c84-9ef3-fe80b7844b3c"), "Canarinho", "C" },
                    { new Guid("909168c3-6467-45c0-9929-66a8b7036891"), "Varzea", "C" },
                    { new Guid("98843bd0-7fca-46cc-9c17-53cbe2951ba1"), "Vasco", "C" },
                    { new Guid("9cff0534-973d-4e0b-885f-7179bb2eaebd"), "Palmeiras", "A" },
                    { new Guid("b97cb710-cceb-456d-8286-2782b53043a3"), "São Paulo", "A" },
                    { new Guid("f06ea5e4-7cc1-4dcd-abbf-d6a9750fdbd8"), "Santos", "B" },
                    { new Guid("f528a929-3f46-45ee-9eda-c2e88961cbc1"), "Ituano", "B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("50dd42ca-1585-4105-81a8-032bbcef0cf1"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("b6fd50f6-8b0a-44cb-9c3e-b39fcf3d5526"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("c007911c-e13d-45b3-8437-4954eca65973"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("d8e00bc4-1a1b-40f0-9080-1cca0c9ef5b5"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("17697393-9f7e-490d-b6d7-f252617d59de"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("1a85f056-9886-4400-9225-4061868dc77f"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("51dd9d2f-3fd2-40d1-a5d1-a550ee478139"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("559a4868-0998-4aef-9bdc-a0bb03c18092"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("7a558ec4-2b9a-4cb8-8284-79ef569e498c"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("84a0fe7f-7721-4a89-b39f-d19ae7cedfd4"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("8dbb9861-0d50-496b-92a4-72cf652b3c3d"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("a774626b-a57b-4e07-9c86-a89bb47e6f68"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("cacf7b1c-ec85-464b-9f89-65e7d30d9135"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("4c005e2a-72d9-4dab-b849-75b3fc9ee61c"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("67c1c3cd-cbc3-4972-8e25-4e113cd03b17"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("73d44936-6042-4c84-9ef3-fe80b7844b3c"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("909168c3-6467-45c0-9929-66a8b7036891"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("98843bd0-7fca-46cc-9c17-53cbe2951ba1"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("9cff0534-973d-4e0b-885f-7179bb2eaebd"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("b97cb710-cceb-456d-8286-2782b53043a3"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("f06ea5e4-7cc1-4dcd-abbf-d6a9750fdbd8"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("f528a929-3f46-45ee-9eda-c2e88961cbc1"));

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "Id", "Nome", "Pontos" },
                values: new object[,]
                {
                    { new Guid("010fbbf9-051b-46f0-a1a2-a7a0065cfe6b"), "Caneleira", 3 },
                    { new Guid("18cae2c1-ab64-49cc-a221-418b2ff86d97"), "Chuteira", 4 },
                    { new Guid("b0bd8fb1-9fa0-4d73-a33c-b3a59ef7e2d4"), "Gatorade", 2 },
                    { new Guid("e208df1e-45cd-45ef-9862-6f0f940fd49c"), "Camisa", 1 }
                });

            migrationBuilder.InsertData(
                table: "Posicoes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("11d80853-27bb-480f-ac27-f798ba328a05"), "Zagueiro" },
                    { new Guid("4fcc5b79-5e98-44c8-84d7-ed6f1e2b3c15"), "Meia" },
                    { new Guid("5a6d80a6-3779-4a48-b97b-f7dbde4ad2af"), "Goleiro" },
                    { new Guid("854d5cc6-091f-4f44-9982-cb74b2f7d35f"), "Volante" },
                    { new Guid("9b49f7dd-7a3b-4559-960c-cab9f07086b3"), "Atacante" },
                    { new Guid("bba324d3-fe29-48f0-9f50-e70e8a2748dd"), "Lateral Esquerda" },
                    { new Guid("e4807816-282c-41d0-a0b3-9f03c1560323"), "Centro Avante" },
                    { new Guid("f0c122f8-0d5d-480e-82e0-402d3c75633b"), "Meia - Atacante" },
                    { new Guid("f5196ad1-29d0-4d30-8e39-95a69a8ec6f3"), "Lateral Direita" }
                });
        }
    }
}
