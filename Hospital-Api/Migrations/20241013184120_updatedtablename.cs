using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Api.Migrations
{
    /// <inheritdoc />
    public partial class updatedtablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medical_AspNetUsers_StaffId",
                table: "Medical");

            migrationBuilder.DropForeignKey(
                name: "FK_Medical_MedicalRecords_MedicalRecordId",
                table: "Medical");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medical",
                table: "Medical");

            migrationBuilder.RenameTable(
                name: "Medical",
                newName: "MedicalRecordHistory");

            migrationBuilder.RenameIndex(
                name: "IX_Medical_StaffId",
                table: "MedicalRecordHistory",
                newName: "IX_MedicalRecordHistory_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Medical_MedicalRecordId",
                table: "MedicalRecordHistory",
                newName: "IX_MedicalRecordHistory_MedicalRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalRecordHistory",
                table: "MedicalRecordHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecordHistory_AspNetUsers_StaffId",
                table: "MedicalRecordHistory",
                column: "StaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecordHistory_MedicalRecords_MedicalRecordId",
                table: "MedicalRecordHistory",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecordHistory_AspNetUsers_StaffId",
                table: "MedicalRecordHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecordHistory_MedicalRecords_MedicalRecordId",
                table: "MedicalRecordHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalRecordHistory",
                table: "MedicalRecordHistory");

            migrationBuilder.RenameTable(
                name: "MedicalRecordHistory",
                newName: "Medical");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecordHistory_StaffId",
                table: "Medical",
                newName: "IX_Medical_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecordHistory_MedicalRecordId",
                table: "Medical",
                newName: "IX_Medical_MedicalRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medical",
                table: "Medical",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_AspNetUsers_StaffId",
                table: "Medical",
                column: "StaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_MedicalRecords_MedicalRecordId",
                table: "Medical",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
