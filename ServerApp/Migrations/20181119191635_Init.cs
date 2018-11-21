using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Strength = table.Column<short>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Health = table.Column<short>(nullable: true),
                    WeaponId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    SourceId = table.Column<int>(nullable: true),
                    TargetId = table.Column<int>(nullable: true),
                    WeaponId = table.Column<int>(nullable: true),
                    Strength = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hits_Character_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hits_Character_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hits_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Discriminator", "Name", "Health" },
                values: new object[,]
                {
                    { 19, "Dragon", "Dragon1", (short)80 },
                    { 35, "Dragon", "Dragon17", (short)80 },
                    { 34, "Dragon", "Dragon16", (short)87 },
                    { 33, "Dragon", "Dragon15", (short)91 },
                    { 32, "Dragon", "Dragon14", (short)99 },
                    { 31, "Dragon", "Dragon13", (short)91 },
                    { 30, "Dragon", "Dragon12", (short)98 },
                    { 29, "Dragon", "Dragon11", (short)92 },
                    { 28, "Dragon", "Dragon10", (short)89 },
                    { 36, "Dragon", "Dragon18", (short)85 },
                    { 26, "Dragon", "Dragon8", (short)82 },
                    { 25, "Dragon", "Dragon7", (short)87 },
                    { 24, "Dragon", "Dragon6", (short)93 },
                    { 23, "Dragon", "Dragon5", (short)100 },
                    { 22, "Dragon", "Dragon4", (short)95 },
                    { 21, "Dragon", "Dragon3", (short)90 },
                    { 20, "Dragon", "Dragon2", (short)85 },
                    { 27, "Dragon", "Dragon9", (short)86 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "Created", "Discriminator", "Name", "Strength" },
                values: new object[,]
                {
                    { 16, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Sword", "Sword", (short)20 },
                    { 15, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Shield", "Shield", (short)15 },
                    { 14, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Shield", "Shield", (short)15 },
                    { 13, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Shield", "Shield", (short)15 },
                    { 12, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Rapier", "Rapier", (short)12 },
                    { 11, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Rapier", "Rapier", (short)12 },
                    { 10, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Rapier", "Rapier", (short)12 },
                    { 9, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Knive", "Knive", (short)8 },
                    { 5, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Crossbow", "Crossbow", (short)20 },
                    { 7, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Knive", "Knive", (short)8 },
                    { 6, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Crossbow", "Crossbow", (short)20 },
                    { 4, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Crossbow", "Crossbow", (short)20 },
                    { 3, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Axe", "Axe", (short)15 },
                    { 2, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Axe", "Axe", (short)15 },
                    { 1, new DateTime(2018, 11, 19, 21, 16, 34, 618, DateTimeKind.Local), "Axe", "Axe", (short)15 },
                    { 17, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Sword", "Sword", (short)20 },
                    { 8, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Knive", "Knive", (short)8 },
                    { 18, new DateTime(2018, 11, 19, 21, 16, 34, 623, DateTimeKind.Local), "Sword", "Sword", (short)20 }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Discriminator", "Name", "WeaponId" },
                values: new object[,]
                {
                    { 1, "Hero", "Hero1", 1 },
                    { 16, "Hero", "Hero16", 16 },
                    { 15, "Hero", "Hero15", 15 },
                    { 14, "Hero", "Hero14", 14 },
                    { 13, "Hero", "Hero13", 13 },
                    { 12, "Hero", "Hero12", 12 },
                    { 11, "Hero", "Hero11", 11 },
                    { 10, "Hero", "Hero10", 10 },
                    { 9, "Hero", "Hero9", 9 },
                    { 8, "Hero", "Hero8", 8 },
                    { 7, "Hero", "Hero7", 7 },
                    { 6, "Hero", "Hero6", 6 },
                    { 5, "Hero", "Hero5", 5 },
                    { 4, "Hero", "Hero4", 4 },
                    { 3, "Hero", "Hero3", 3 },
                    { 2, "Hero", "Hero2", 2 },
                    { 17, "Hero", "Hero17", 17 },
                    { 18, "Hero", "Hero18", 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_Name",
                table: "Character",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Character_WeaponId",
                table: "Character",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Hits_SourceId",
                table: "Hits",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Hits_TargetId",
                table: "Hits",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Hits_WeaponId",
                table: "Hits",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hits");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
