using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class priceadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_Person_PersonID",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchaseinvoiceitems_Product_ProductID",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchaseinvoiceitems_PurchaseInvoice_PurchaseinvoiceID",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropIndex(
                name: "IX_Purchaseinvoiceitems_ProductID",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropIndex(
                name: "IX_Purchaseinvoiceitems_PurchaseinvoiceID",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_PersonID",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropColumn(
                name: "PurchaseinvoiceID",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "PurchaseInvoice");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Purchaseinvoiceitems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Purchaseinvoiceitems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "PurchaseInvoice",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseinvoiceitems_Idcommodity",
                table: "Purchaseinvoiceitems",
                column: "Idcommodity");

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseinvoiceitems_Idpruchaseinvoice",
                table: "Purchaseinvoiceitems",
                column: "Idpruchaseinvoice");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_IDPerson",
                table: "PurchaseInvoice",
                column: "IDPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_Person_IDPerson",
                table: "PurchaseInvoice",
                column: "IDPerson",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchaseinvoiceitems_Product_Idcommodity",
                table: "Purchaseinvoiceitems",
                column: "Idcommodity",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchaseinvoiceitems_PurchaseInvoice_Idpruchaseinvoice",
                table: "Purchaseinvoiceitems",
                column: "Idpruchaseinvoice",
                principalTable: "PurchaseInvoice",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_Person_IDPerson",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchaseinvoiceitems_Product_Idcommodity",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchaseinvoiceitems_PurchaseInvoice_Idpruchaseinvoice",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropIndex(
                name: "IX_Purchaseinvoiceitems_Idcommodity",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropIndex(
                name: "IX_Purchaseinvoiceitems_Idpruchaseinvoice",
                table: "Purchaseinvoiceitems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_IDPerson",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Purchaseinvoiceitems");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Purchaseinvoiceitems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Purchaseinvoiceitems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseinvoiceID",
                table: "Purchaseinvoiceitems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "PurchaseInvoice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "PurchaseInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseinvoiceitems_ProductID",
                table: "Purchaseinvoiceitems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseinvoiceitems_PurchaseinvoiceID",
                table: "Purchaseinvoiceitems",
                column: "PurchaseinvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_PersonID",
                table: "PurchaseInvoice",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_Person_PersonID",
                table: "PurchaseInvoice",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchaseinvoiceitems_Product_ProductID",
                table: "Purchaseinvoiceitems",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchaseinvoiceitems_PurchaseInvoice_PurchaseinvoiceID",
                table: "Purchaseinvoiceitems",
                column: "PurchaseinvoiceID",
                principalTable: "PurchaseInvoice",
                principalColumn: "ID");
        }
    }
}
