using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefansSuperShop.Migrations
{
    public partial class newsletter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Newsletters",
                columns: table => new
                {
                    NewsletterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletters", x => x.NewsletterID);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    NewsletterSubscriberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.NewsletterSubscriberID);
                });

            migrationBuilder.CreateTable(
                name: "NewsletterNewsletterSubscriber",
                columns: table => new
                {
                    NewslettersNewsletterId = table.Column<int>(type: "int", nullable: false),
                    SubscribersNewsletterSubscriberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsletterNewsletterSubscriber", x => new { x.NewslettersNewsletterId, x.SubscribersNewsletterSubscriberId });
                    table.ForeignKey(
                        name: "FK_NewsletterNewsletterSubscriber_Newsletters_NewslettersNewsletterId",
                        column: x => x.NewslettersNewsletterId,
                        principalTable: "Newsletters",
                        principalColumn: "NewsletterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsletterNewsletterSubscriber_Subscribers_SubscribersNewsletterSubscriberId",
                        column: x => x.SubscribersNewsletterSubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "NewsletterSubscriberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterNewsletterSubscriber_SubscribersNewsletterSubscriberId",
                table: "NewsletterNewsletterSubscriber",
                column: "SubscribersNewsletterSubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsletterNewsletterSubscriber");

            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropTable(
                name: "Subscribers");
        }
    }
}
