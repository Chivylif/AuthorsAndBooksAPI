using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorsAndBooksAPI.Migrations
{
    public partial class Seedingthedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "33", "ikenna@gmail.com", "Ikenna", "Ogbonna" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Email", "FirstName", "LastName" },
                values: new object[] { 2, "29", "nelson@yahoo.com", "Nelson", "Okoro" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "32", "osigwe@gmail.com", "Dozie", "Osigwe" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Email", "FirstName", "LastName" },
                values: new object[] { 4, "23", "akinkumi@gmail.com", "Akinkumi", "Ogbonna" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ProductionYear", "Title" },
                values: new object[] { 1, 1, " The depth of our expertise is defined by a carefully selected pool of consultants who ensure that we continue to be the firm of choice to our growing list of discerning clienteles.", "1990", "Things Fall Apart" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ProductionYear", "Title" },
                values: new object[] { 2, 2, "Jobrole Consulting Limited is a Talent Management Company that offers innovative talent and business solutions to drive performance and acceleration. Our focus is to develop and implement new ideas and strategies for Organizations to enhance their business processes and growth.", "1993", "The beautiful ones are yet to be born" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ProductionYear", "Title" },
                values: new object[] { 3, 3, "Our focus is to develop and implement new ideas and strategies for Organizations to enhance their business processes and growth.", "2000", "The burning man" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ProductionYear", "Title" },
                values: new object[] { 4, 4, "The man from another planet is a book written by Akinkumi a renowned writter is about a man that came from another planet, exploits on earth and his love life.", "2001", "The man from another planet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
