using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultingCompany.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addarabicname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Services",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Services");
        }
    }
}
