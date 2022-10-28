using Microsoft.EntityFrameworkCore.Migrations;

namespace NationalParks.Migrations
{
    public partial class Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Cost", "Country", "Name", "State" },
                values: new object[,]
                {
                    { 2, 35, "USA", "Yosemite National Park", "California" },
                    { 3, 35, "USA", "Grand Canyon National Park", "Arizona" },
                    { 4, 20, "USA", "Yellowstone National Park", "Wyoming" },
                    { 5, 10, "Canada", "Jasper National Park", "Alberta" }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 1,
                column: "Description",
                value: "Multiple lodges to choose from");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Cost", "Description", "Name", "ParkId", "Type" },
                values: new object[,]
                {
                    { 2, 80, "Boat, bus, raft and horseback tours available", "Guided Tours", 1, "Tours" },
                    { 3, 40, "First come first serve, with overnight parking ", "Wilderness Camping", 1, "Camping" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Cost", "Description", "Name", "ParkId", "Type" },
                values: new object[,]
                {
                    { 4, 120, "Tent cabins at  High Sierra Camps / deluxe rooms at The Ahwahnee", "Yosemite Lodging", 2, "Lodging" },
                    { 5, 40, "Ranger-led programs may be available on a limited basis", "Ranger & Interpretive Programs", 2, "Program" },
                    { 6, 90, "South Rim lodging is available all year", "South Rim Lodgine", 3, "Lodging" },
                    { 7, 0, "23 mile scenic road between Desert View and Grand Canyon Village,", "Desert View", 3, "Scenery" },
                    { 8, 0, "coffee bar, grab-and-go breakfast and Lunch, and hiker/biker supplies", "Grand Canyon Vistor Center", 3, "Amenities" },
                    { 9, 30, "12 campgrounds with over 2,000 established campsites.", "Yosemite Campgrounds", 4, "Camping" },
                    { 10, 0, "Hottest hot springs in the Canadian Rockies", "Miette Hot Springs", 5, "Scenery" },
                    { 11, 140, "See elk, deer, bear, moose and mountain goats ", "Wildlife Tours", 5, "Tours" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 1,
                column: "Description",
                value: "Our guest experience is characterized by warm, personalized service and convenient in-room amenities to make the most of your stay in Glacier National Park.");
        }
    }
}
