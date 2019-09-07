using Microsoft.EntityFrameworkCore.Migrations;

namespace hachathon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: false),
                    Available = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneId = table.Column<int>(nullable: false),
                    PlanId = table.Column<int>(nullable: false),
                    Ssn = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 15, "114-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 14, "662-555-9551" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 13, "552-532-9191" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 12, "442-552-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 11, "332-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 9, "112-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 8, "912-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 10, "222-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 6, "702-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 5, "612-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 4, "502-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 3, "402-552-9291" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 2, "312-532-9911" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 1, "212-532-9991" });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "Number" },
                values: new object[] { 7, "812-532-9991" });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 1, "Plan for a every body", "Start Kit", 10.99m });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 2, "Unlimited data, calls, messages", "Unlimited Kit", 20.10m });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 3, "Special service.", "Gold Kit", 40.22m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Approved" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "In Progress" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Rejected" });

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserId",
                table: "Document",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PhoneId",
                table: "User",
                column: "PhoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PlanId",
                table: "User",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StatusId",
                table: "User",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
