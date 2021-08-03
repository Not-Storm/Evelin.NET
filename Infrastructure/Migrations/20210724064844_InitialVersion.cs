namespace Infrastructure.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// System Generated.
    /// </summary>
    public partial class InitialVersion : Migration
    {
        /// <summary>
        /// System Generated.
        /// </summary>
        /// <param name="migrationBuilder">System generated.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });
        }

        /// <summary>
        /// System Generated.
        /// </summary>
        /// <param name="migrationBuilder">Systemgenerated.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
