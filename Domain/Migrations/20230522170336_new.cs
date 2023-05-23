using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseInvoice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoicenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDPerson = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoice_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Purchaseinvoiceitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idcommodity = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Idpruchaseinvoice = table.Column<int>(type: "int", nullable: true),
                    PurchaseinvoiceID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchaseinvoiceitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchaseinvoiceitems_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Purchaseinvoiceitems_PurchaseInvoice_PurchaseinvoiceID",
                        column: x => x.PurchaseinvoiceID,
                        principalTable: "PurchaseInvoice",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_PersonID",
                table: "PurchaseInvoice",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseinvoiceitems_ProductID",
                table: "Purchaseinvoiceitems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseinvoiceitems_PurchaseinvoiceID",
                table: "Purchaseinvoiceitems",
                column: "PurchaseinvoiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchaseinvoiceitems");

            migrationBuilder.DropTable(
                name: "PurchaseInvoice");
        }
    }
}
