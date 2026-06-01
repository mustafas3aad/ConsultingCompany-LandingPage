using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultingCompany.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ConsultationRequest_Phone",
                table: "ConsultationRequests");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ConsultationRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ConsultationRequests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ConsultationRequest_Phone",
                table: "ConsultationRequests",
                sql: "Phone LIKE '01[0125][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
        }
    }
}
