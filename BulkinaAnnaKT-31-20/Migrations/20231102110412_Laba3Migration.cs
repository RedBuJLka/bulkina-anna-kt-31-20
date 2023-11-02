using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkinaAnnaKT_31_20.Migrations
{
    /// <inheritdoc />
    public partial class Laba3Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "ID группы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_group_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 50, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false, comment: "ID студента")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Имя"),
                    c_student_surname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Фамилия"),
                    c_student_patronym = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Отчество"),
                    f_group_id = table.Column<int>(type: "int", nullable: false, comment: "ID группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
