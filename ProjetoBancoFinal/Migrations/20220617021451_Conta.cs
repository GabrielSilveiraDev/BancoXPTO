using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBancoFinal.Migrations
{
    public partial class Conta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Conta_ContaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChavesPix_Conta_ContaId",
                table: "ChavesPix");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conta",
                table: "Conta");

            migrationBuilder.RenameTable(
                name: "Conta",
                newName: "Contas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Contas_ContaId",
                table: "AspNetUsers",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChavesPix_Contas_ContaId",
                table: "ChavesPix",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Contas_ContaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChavesPix_Contas_ContaId",
                table: "ChavesPix");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.RenameTable(
                name: "Contas",
                newName: "Conta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conta",
                table: "Conta",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Conta_ContaId",
                table: "AspNetUsers",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChavesPix_Conta_ContaId",
                table: "ChavesPix",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
