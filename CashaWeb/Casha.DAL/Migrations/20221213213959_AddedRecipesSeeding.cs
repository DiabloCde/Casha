using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Casha.DAL.Migrations
{
    public partial class AddedRecipesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a593ddb-abaa-418d-89ad-56366e8cebba", "AQAAAAEAACcQAAAAECrubOlwsbAqioDfrp6R3iCtmmWkypW24pVfwxbOXrLwBkl5Mb1P/ovlhiyTGw3UAw==", "b126b7f4-ab32-431b-8c1e-cf7b85f82baf" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { 1, "Ukrainian", 1 },
                    { 2, "Italian", 1 },
                    { 3, "French", 1 },
                    { 4, "English", 1 },
                    { 5, "Japanese", 1 },
                    { 6, "Chinese", 1 },
                    { 7, "Korean", 1 },
                    { 8, "New Year", 0 },
                    { 9, "Easter", 0 },
                    { 10, "Thanksgiving", 0 },
                    { 11, "Christmas", 0 },
                    { 12, "Birthday", 0 },
                    { 13, "Swedish", 1 },
                    { 14, "Thai", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name" },
                values: new object[,]
                {
                    { 1, "Grapefruit" },
                    { 2, "Salt" },
                    { 3, "Black pepper" },
                    { 4, "Chicken" },
                    { 5, "Parsley" },
                    { 6, "Bacon" },
                    { 7, "Olive oil" },
                    { 8, "Cognak" },
                    { 9, "Cream" },
                    { 10, "White rice" },
                    { 11, "Water" },
                    { 12, "Rice vinegar" },
                    { 13, "Vegetable oil" },
                    { 14, "White sugar" },
                    { 15, "Butter" },
                    { 16, "Flour" },
                    { 17, "Milk" },
                    { 18, "Species" },
                    { 19, "Spinach" },
                    { 20, "Salmon fillet" },
                    { 21, "Double cream" },
                    { 22, "Risotto rice" },
                    { 23, "Chicken stock" },
                    { 24, "Pesto" },
                    { 25, "Goat's cheese" },
                    { 26, "Thai green curry paste" },
                    { 27, "Coconut milk" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name" },
                values: new object[,]
                {
                    { 28, "Prawns" },
                    { 29, "Courgetti" },
                    { 30, "Lamb" },
                    { 31, "Onion" },
                    { 32, "Thyme" },
                    { 33, "Red wine" },
                    { 34, "Watercress" },
                    { 35, "Feta" },
                    { 36, "Self-raising flour" },
                    { 37, "Sparkling water" },
                    { 38, "Groundnut oil" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Difficulty", "Instruction", "Name", "RecipeImageUrl", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Working over a bowl to collect juice, section grapefruits into suprêmes, cutting away all peel, pith, and membranes. Squeeze remaining skin and membranes into the bowl to extract as much juice as possible.\r\n\r\nPreheat the oven to 375 degrees F (190 degrees C).\r\n\r\nStir together salt and pepper in a small bowl. Slip fingers beneath the skin of the chicken breast and thighs to loosen it from the meat. Rub salt mixture under skin, inside cavity, and over skin. Tuck half the suprêmes and a few parsley sprigs into chicken cavity. Transfer chicken, breast side up, to a rack in a baking dish or a cast-iron skillet.\r\n\r\nTie legs together with kitchen twine; fold wing tips back and tuck under chicken. Halve bacon; drape over breast in a herringbone pattern, overlapping as needed. Drizzle with oil, coating any uncovered skin.\r\n\r\nRoast in the preheated oven for 40 minutes. Pour grapefruit juice over chicken. Continue roasting 35 to 40 minutes or until an instant-read thermometer inserted into thickest parts of thigh and breast registers 170°F. Tent with foil; let rest at least 15 minutes. Discard kitchen twine. Remove and reserve suprêmes from chicken cavity.\r\n\r\nFor sauce, warm cognac in a small stainless-steel or copper (not nonstick) skillet over medium heat for a few seconds until shimmering at the edges. Remove from heat.\r\n\r\nCarefully ignite with a stick lighter or long match. Let burn for 1 minute. Add roasted grapefruit suprêmes, the broth, and half-and-half; heat through. Season to taste with salt and pepper.\r\n\r\nServe chicken on a platter with remaining fresh suprêmes (or extra grapefruit wedges) and parsley sprigs. Spoon warm sauce over carved chicken.", "Roast Chicken with Grapefruit", "string", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 2, 0, "Rinse the rice in a strainer or colander under cold running water until the water runs clear.\r\n\r\nCombine rice and water in a saucepan over medium-high heat and bring to a boil. Reduce heat to low, cover, and cook until rice is tender and all water has been absorbed, about 20 minutes. Remove from stove and set aside until cool enough to handle.\r\n\r\nMeanwhile, combine rice vinegar, oil, sugar, and salt in a small saucepan over medium heat. Cook until the sugar has dissolved. Allow to cool, then stir into the cooked rice. While mixture will appear very wet at first, keep stirring and rice will dry as it cools.", "Perfect Sushi Rice", "string", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 3, 0, "Melt butter in a large saucepan over medium heat. Add flour and whisk into the melted butter until smooth. Cook and stir until flour turns a light, golden, sandy color, about 7 minutes.\r\n\r\nIncrease heat to medium-high and slowly whisk in milk until thickened by the roux. Bring to a gentle simmer, then reduce heat to medium-low and continue simmering until the flour has softened and no longer tastes gritty, 10 to 20 minutes. Season with salt and species.", "Bechamel sause", "string", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 4, 0, "STEP 1\r\nPut the spinach in a really big saucepan (or two saucepans) and add a few tablespoons of water. Cover, set over a medium heat and cook for about 5-8 mins, turning the spinach over every so often, until wilted. Tip it into a colander to drain and allow it to cool (spread it out on a plate to cool it quicker). Take big handfuls of it in your fists and squeeze out the excess water. It’s really important that you do this, otherwise the water will leach out and make the cream watery and green.\r\n\r\nSTEP 2\r\nChop the spinach. Melt the butter in a saucepan and gently toss the spinach in it. Season with pepper and a tiny bit of salt (there’s so much salt in the salmon). Heat the oven to 160C/140C fan/gas 3. Lay the spinach in the bottom of a gratin dish (about 30cm x 20cm), then arrange the salmon fillets on top.\r\n\r\nSTEP 3\r\nHeat the double cream in a small pan, then pour it all over the salmon and spinach. Bake for 35 mins, or until the top is golden and the cream is bubbling.", "Smoked salmon & spinach gratin", "string", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 5, 0, "STEP 1\r\nPour a glug of olive oil into a large saucepan. Tip in the rice and fry for 1 min. Add half the stock and cook until absorbed. Add the remaining stock, a ladle at a time, and cook until the rice is al dente, stirring continually, for 20-25 mins.\r\n\r\nSTEP 2\r\nStir through the pesto and half the goat’s cheese. Serve topped with the remaining cheese.", "Pesto & goat's cheese risotto", "string", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 6, 0, "Heat 1 tsp flavourless oil in a frying pan over a medium heat. Add the curry paste and cook for 1 min. Pour in the coconut milk, then leave to bubble away for a few mins before adding the prawns and courgetti. Cook for 1 min more to warm through, then divide between bowls.", "Prawn & coconut soup", "string", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 7, 0, "STEP 1\r\nFirstly, prepare the lamb. Heat oven to 160C/fan140C/gas 3. Wipe the meat all over and season well. Heat 3 tbsp of olive oil in a large heavy flameproof casserole, add the meat and fry all over on a fairly high heat for about 8 mins, turning until it is evenly well browned. Remove to a plate.\r\n\r\nSTEP 2\r\nThinly slice the onions. Add to the pan and fry for about 10 mins, until softened and tinged with brown. Add a few of the thyme sprigs and cook for a further minute or so. Season with salt and pepper.\r\n\r\nSTEP 3\r\nSit the lamb on top of the onions, then add the wine. Cover tightly. Bake for 3 hrs. You can make to this stage up to 2 days in advance, then reheat for 45 mins.\r\n\r\nSTEP 4\r\nTo finish off, strip the leaves from 2 thyme sprigs and chop them with the parsley. Scatter over before serving.", "Slow-cooked lamb with onions & thyme", "string", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 8, 0, "STEP 1\r\nHeat oven to 200C/180C fan/ gas 6 and roast the salmon for 8 mins. Meanwhile, segment the grapefruit and mix the juices with 2 tbsp extra virgin olive oil to make a dressing.\r\n\r\nSTEP 2\r\nToss the watercress with the grapefruit segments, dressing and feta, and serve with the salmon, flaked into large pieces.", "Citrus salmon salad", "string", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 9, 0, "STEP 1\r\nUse a fork to steady your onion. Slice the onion into rings about 1cm wide. Remove the skin and separate the rings.\r\n\r\nSTEP 2\r\nHeat the oil to 180C in a heavy-based pan – it should be no more than 1/ 3 full.\r\n\r\nSTEP 3\r\nMeanwhile put the flour and sparkling water in a bowl and season generously. Whisk together to form a batter.\r\n\r\nSTEP 4\r\nCoat a small batch of onion rings in batter. Carefully lower into the hot oil and deep-fry until crisp and golden, about 2 - 3 minutes. Remove with a slotted spoon and place on a piece of kitchen towel to drain. Repeat with the remaining onion and batter.", "Onion rings", "string", "b74ddd14-6340-4840-95c2-db12554843e5" }
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "CategoryId", "RecipeId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 11, 1 },
                    { 5, 2 },
                    { 2, 3 },
                    { 13, 4 },
                    { 2, 5 },
                    { 14, 6 },
                    { 4, 7 },
                    { 3, 8 },
                    { 4, 9 }
                });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ProductId", "RecipeId", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, 1, 3.0, 4 },
                    { 2, 1, 1.0, 1 },
                    { 3, 1, 1.5, 0 },
                    { 4, 1, 1.0, 4 },
                    { 5, 1, 25.0, 2 },
                    { 6, 1, 150.0, 2 },
                    { 7, 1, 1.0, 1 },
                    { 8, 1, 1.0, 1 },
                    { 9, 1, 1.0, 0 },
                    { 3, 2, 1.0, 0 },
                    { 10, 2, 400.0, 2 },
                    { 11, 2, 750.0, 2 },
                    { 12, 2, 4.0, 1 },
                    { 13, 2, 1.0, 1 },
                    { 14, 2, 2.0, 1 },
                    { 3, 3, 1.0, 0 },
                    { 15, 3, 5.0, 1 },
                    { 16, 3, 4.0, 1 },
                    { 17, 3, 300.0, 3 },
                    { 18, 3, 0.25, 0 },
                    { 15, 4, 15.0, 2 },
                    { 19, 4, 1200.0, 2 },
                    { 20, 4, 1000.0, 2 },
                    { 21, 4, 300.0, 3 },
                    { 7, 5, 20.0, 2 },
                    { 22, 5, 200.0, 2 },
                    { 23, 5, 700.0, 3 },
                    { 24, 5, 250.0, 2 },
                    { 25, 5, 100.0, 2 },
                    { 26, 6, 3.0, 1 },
                    { 27, 6, 400.0, 3 },
                    { 28, 6, 150.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ProductId", "RecipeId", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 29, 6, 250.0, 2 },
                    { 5, 7, 30.0, 2 },
                    { 30, 7, 1250.0, 2 },
                    { 31, 7, 1000.0, 2 },
                    { 32, 7, 30.0, 2 },
                    { 33, 7, 300.0, 3 },
                    { 1, 8, 1.0, 4 },
                    { 20, 8, 2.0, 4 },
                    { 34, 8, 100.0, 2 },
                    { 35, 8, 200.0, 2 },
                    { 31, 9, 1.0, 4 },
                    { 36, 9, 150.0, 2 },
                    { 37, 9, 180.0, 3 },
                    { 38, 9, 150.0, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 19, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 20, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 21, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 22, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 23, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 24, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 25, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 26, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 27, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 28, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 29, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 30, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 31, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 32, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 33, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 20, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 34, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 35, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 31, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 36, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 37, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 38, 9 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "458e44e0-1c3e-46bd-8679-95bab2419f3d", "AQAAAAEAACcQAAAAENxLu0ex6UtvesEcfQvYd0O4wL8eYNelMBf2zHwJU092h1TvhVqJHRfKgsDl3c2/AQ==", "9a583c6b-dca3-4bfc-b00a-e3cc7c2aa601" });
        }
    }
}
