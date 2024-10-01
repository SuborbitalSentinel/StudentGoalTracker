using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goal_tracker.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUsageOfName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Goals",
                newName: "GoalName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GoalName",
                table: "Goals",
                newName: "Name");
        }
    }
}
