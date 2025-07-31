using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorialsAPI.Migrations
{
    /// <inheritdoc />
    public partial class detailsssds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TopicCover",
                table: "CourseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopicCover",
                table: "CourseDetails");
        }
    }
}
