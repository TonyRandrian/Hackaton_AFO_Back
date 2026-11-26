using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientsRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Objet = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Infos = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    LogoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    LogoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Contents = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealizationImageTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizationImageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Subtitle = table.Column<string>(type: "text", nullable: true),
                    ServiceDescription = table.Column<string>(type: "text", nullable: true),
                    ExpertiseDescription = table.Column<string>(type: "text", nullable: true),
                    RealizationDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LogoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Subtitle = table.Column<string>(type: "text", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQs_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: true),
                    Note = table.Column<decimal>(type: "numeric(2,1)", precision: 2, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ServiceContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceContents_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceExpertises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Contents = table.Column<List<string>>(type: "text[]", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceExpertises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceExpertises_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProcessus",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcessusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProcessus", x => new { x.ServiceId, x.ProcessusId });
                    table.ForeignKey(
                        name: "FK_ServiceProcessus_Processus_ProcessusId",
                        column: x => x.ProcessusId,
                        principalTable: "Processus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProcessus_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogArticles_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceContentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Includes = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricings_ServiceContents_ServiceContentId",
                        column: x => x.ServiceContentId,
                        principalTable: "ServiceContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SubTitle = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    ProjectUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AboutDescription = table.Column<string>(type: "text", nullable: false),
                    ProjectDescription = table.Column<string>(type: "text", nullable: false),
                    GoalDescription = table.Column<string>(type: "text", nullable: false),
                    Qualities = table.Column<List<string>>(type: "text[]", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceContentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realizations_ServiceContents_ServiceContentId",
                        column: x => x.ServiceContentId,
                        principalTable: "ServiceContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Realizations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogArticleImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    BlogArticleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogArticleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogArticleImages_BlogArticles_BlogArticleId",
                        column: x => x.BlogArticleId,
                        principalTable: "BlogArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealizationAdvantages",
                columns: table => new
                {
                    AdvantageId = table.Column<Guid>(type: "uuid", nullable: false),
                    RealizationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizationAdvantages", x => new { x.RealizationId, x.AdvantageId });
                    table.ForeignKey(
                        name: "FK_RealizationAdvantages_Advantages_AdvantageId",
                        column: x => x.AdvantageId,
                        principalTable: "Advantages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealizationAdvantages_Realizations_RealizationId",
                        column: x => x.RealizationId,
                        principalTable: "Realizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealizationImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RealizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    RealizationImageTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealizationImages_RealizationImageTypes_RealizationImageTyp~",
                        column: x => x.RealizationImageTypeId,
                        principalTable: "RealizationImageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealizationImages_Realizations_RealizationId",
                        column: x => x.RealizationId,
                        principalTable: "Realizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealizationProcessus",
                columns: table => new
                {
                    RealizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcessusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizationProcessus", x => new { x.RealizationId, x.ProcessusId });
                    table.ForeignKey(
                        name: "FK_RealizationProcessus_Processus_ProcessusId",
                        column: x => x.ProcessusId,
                        principalTable: "Processus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealizationProcessus_Realizations_RealizationId",
                        column: x => x.RealizationId,
                        principalTable: "Realizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealizationTechnologies",
                columns: table => new
                {
                    RealizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    TechnologyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizationTechnologies", x => new { x.RealizationId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_RealizationTechnologies_Realizations_RealizationId",
                        column: x => x.RealizationId,
                        principalTable: "Realizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealizationTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogArticleImages_BlogArticleId",
                table: "BlogArticleImages",
                column: "BlogArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogArticles_BlogId",
                table: "BlogArticles",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ServiceId",
                table: "Blogs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_ServiceId",
                table: "FAQs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ServiceId",
                table: "Feedbacks",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_ServiceContentId",
                table: "Pricings",
                column: "ServiceContentId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationAdvantages_AdvantageId",
                table: "RealizationAdvantages",
                column: "AdvantageId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationImages_RealizationId",
                table: "RealizationImages",
                column: "RealizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationImages_RealizationImageTypeId",
                table: "RealizationImages",
                column: "RealizationImageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationImageTypes_Name",
                table: "RealizationImageTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealizationProcessus_ProcessusId",
                table: "RealizationProcessus",
                column: "ProcessusId");

            migrationBuilder.CreateIndex(
                name: "IX_Realizations_ServiceContentId",
                table: "Realizations",
                column: "ServiceContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Realizations_ServiceId",
                table: "Realizations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationTechnologies_TechnologyId",
                table: "RealizationTechnologies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceContents_ServiceId",
                table: "ServiceContents",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceExpertises_ServiceId",
                table: "ServiceExpertises",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProcessus_ProcessusId",
                table: "ServiceProcessus",
                column: "ProcessusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogArticleImages");

            migrationBuilder.DropTable(
                name: "ClientsRequests");

            migrationBuilder.DropTable(
                name: "CompanyInformations");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "RealizationAdvantages");

            migrationBuilder.DropTable(
                name: "RealizationImages");

            migrationBuilder.DropTable(
                name: "RealizationProcessus");

            migrationBuilder.DropTable(
                name: "RealizationTechnologies");

            migrationBuilder.DropTable(
                name: "ServiceExpertises");

            migrationBuilder.DropTable(
                name: "ServiceProcessus");

            migrationBuilder.DropTable(
                name: "BlogArticles");

            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropTable(
                name: "RealizationImageTypes");

            migrationBuilder.DropTable(
                name: "Realizations");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Processus");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "ServiceContents");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
