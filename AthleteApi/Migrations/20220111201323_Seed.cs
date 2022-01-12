using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AthleteApi.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1991, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Anna Gasser" },
                    { 2, new DateTime(2001, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Tess Ledeux" },
                    { 3, new DateTime(1990, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Nairo Quintana" }
                });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "World Snowboard Tour", 2010 },
                    { 2, "World Snowboard Tour", 2011 },
                    { 3, "Winter Olympics", 2014 },
                    { 4, "FIS Snowboarding World Championship", 2015 },
                    { 5, "FIS Freestyle World Championship", 2017 },
                    { 6, "Route du Sud", 2012 },
                    { 7, "Tour of the Basque Country", 2013 },
                    { 8, "Tour de France", 2014 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "SupersetName" },
                values: new object[,]
                {
                    { 1, "Snowboarding", "Winter sports" },
                    { 2, "Gymnastics", null },
                    { 3, "Skiing", "Winter sports" },
                    { 4, "Cycling", null }
                });

            migrationBuilder.InsertData(
                table: "AthleteSkill",
                columns: new[] { "AthletesId", "SkillsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "AthleteChampionship",
                columns: new[] { "AthletesId", "ChampionshipsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Athletes\";", true);
            migrationBuilder.Sql("DELETE FROM \"Skills\";", true);
            migrationBuilder.Sql("DELETE FROM \"Championships\";", true);
            migrationBuilder.Sql("DELETE FROM \"AthleteChampionship\";", true);
            migrationBuilder.Sql("DELETE FROM \"AthleteSkill\";", true);
        }
    }
}
