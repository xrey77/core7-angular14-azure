using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace core7_angular14_azure.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterColumn<string>(
            //     name: "qrcodeurl",
            //     table: "users",
            //     type: "ntext",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(max)",
            //     oldNullable: true);

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: false),
                    unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cost_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    sell_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    prod_pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sale_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    alert_level = table.Column<int>(type: "int", nullable: false),
                    critical_level = table.Column<int>(type: "int", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateupdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            // migrationBuilder.AlterColumn<string>(
            //     name: "qrcodeurl",
            //     table: "users",
            //     type: "nvarchar(max)",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "ntext",
            //     oldNullable: true);
        }
    }
}
