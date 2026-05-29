using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultingCompany.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedValidations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconName",
                table: "Services");

            migrationBuilder.AddCheckConstraint(
                name: "CK_NewsletterSubscriber_Email",
                table: "NewsletterSubscribers",
                sql: "Email LIKE '_%@_%._%'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ConsultationRequest_Email",
                table: "ConsultationRequests",
                sql: "Email LIKE '_%@_%._%'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ConsultationRequest_Phone",
                table: "ConsultationRequests",
                sql: "Phone LIKE '01[0125][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_NewsletterSubscriber_Email",
                table: "NewsletterSubscribers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_ConsultationRequest_Email",
                table: "ConsultationRequests");

            migrationBuilder.DropCheckConstraint(
                name: "CK_ConsultationRequest_Phone",
                table: "ConsultationRequests");

            migrationBuilder.AddColumn<string>(
                name: "IconName",
                table: "Services",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
