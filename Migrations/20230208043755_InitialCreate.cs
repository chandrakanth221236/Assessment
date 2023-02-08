using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Text;

namespace Chandrakanth_CRUD.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Book_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    AuthorLastName = table.Column<string>(nullable: true),
                    AuthorFirstName = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Style_Citation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Book_id);
                });


            StringBuilder storedProcedureCode = new StringBuilder();
            storedProcedureCode.Append("CREATE PROCEDURE dbo.GetAllBookDataDefaultSort" + Environment.NewLine);
            storedProcedureCode.Append("AS" + Environment.NewLine);
            storedProcedureCode.Append("BEGIN" + Environment.NewLine);
            storedProcedureCode.Append(@" 'SELECT * from Book order by Publisher,AuthorLastName,AuthorFirstName,Title' " + Environment.NewLine);
            storedProcedureCode.Append("END" + Environment.NewLine);

            migrationBuilder.Sql(storedProcedureCode.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.Sql("DROP PROCEDURE dbo.GetAllBookDataDefaultSort");
        }
    }
}
