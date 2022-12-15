using Casha.Core.DbModels;
using Casha.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }  

        public DbSet<Product> Products { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeCategory> RecipeCategories { get; set; }

        public DbSet<RecipeProduct> RecipeProducts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProduct> UserProducts { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        private void SeedUsers(ModelBuilder builder)
        {
            User user = new User
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                IsCertified = true,
                FirstName = "admin",
                LastName = "admin",
                DisplayName = "admin",
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            var password = passwordHasher.HashPassword(user, "Admin123*");
            user.PasswordHash = password;
            builder.Entity<User>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
        }

        private void SeedRecipes(ModelBuilder builder)
        {
            List<Category> categories = new List<Category> {
                new Category { CategoryId = 1, CategoryName = "Ukrainian", CategoryType = CategoryType.Cuisine },//0
                new Category { CategoryId = 2, CategoryName = "Italian", CategoryType = CategoryType.Cuisine },//1
                new Category { CategoryId = 3, CategoryName = "French", CategoryType = CategoryType.Cuisine },//2
                new Category { CategoryId = 4, CategoryName = "English", CategoryType = CategoryType.Cuisine },//3
                new Category { CategoryId = 5, CategoryName = "Japanese", CategoryType = CategoryType.Cuisine },//4
                new Category { CategoryId = 6, CategoryName = "Chinese", CategoryType = CategoryType.Cuisine },//5
                new Category { CategoryId = 7, CategoryName = "Korean", CategoryType = CategoryType.Cuisine },//6
                new Category { CategoryId = 8, CategoryName = "New Year", CategoryType = CategoryType.Occasion },//7
                new Category { CategoryId = 9, CategoryName = "Easter", CategoryType = CategoryType.Occasion },//8
                new Category { CategoryId = 10, CategoryName = "Thanksgiving", CategoryType = CategoryType.Occasion },//9
                new Category { CategoryId = 11, CategoryName = "Christmas", CategoryType = CategoryType.Occasion },//10
                new Category { CategoryId = 12, CategoryName = "Birthday", CategoryType = CategoryType.Occasion },//11
                new Category { CategoryId = 13, CategoryName = "Swedish", CategoryType = CategoryType.Cuisine },//12
                new Category { CategoryId = 14, CategoryName = "Thai", CategoryType = CategoryType.Cuisine },//13
            };

            List<Product> products = new List<Product> {
                new Product { ProductId = 1, Name = "Grapefruit" },//0
                new Product { ProductId = 2, Name = "Salt" },//1
                new Product { ProductId = 3, Name = "Black pepper" },//2
                new Product { ProductId = 4, Name = "Chicken" },//3
                new Product { ProductId = 5, Name = "Parsley" },//4
                new Product { ProductId = 6, Name = "Bacon" },//5
                new Product { ProductId = 7, Name = "Olive oil" },//6
                new Product { ProductId = 8, Name = "Cognak" },//7
                new Product { ProductId = 9, Name = "Cream" },//8
                new Product { ProductId = 10, Name = "White rice" },//9
                new Product { ProductId = 11, Name = "Water" },//10
                new Product { ProductId = 12, Name = "Rice vinegar" },//11
                new Product { ProductId = 13, Name = "Vegetable oil" },//12
                new Product { ProductId = 14, Name = "White sugar" },//13               
                new Product { ProductId = 15, Name = "Butter" },//14
                new Product { ProductId = 16, Name = "Flour" },//15
                new Product { ProductId = 17, Name = "Milk" },//16
                new Product { ProductId = 18, Name = "Species" },//17
                new Product { ProductId = 19, Name = "Spinach" },//18
                new Product { ProductId = 20, Name = "Salmon fillet" },//19
                new Product { ProductId = 21, Name = "Double cream" },//20
                new Product { ProductId = 22, Name = "Risotto rice" },//21
                new Product { ProductId = 23, Name = "Chicken stock" },//22
                new Product { ProductId = 24, Name = "Pesto" },//23
                new Product { ProductId = 25, Name = "Goat's cheese" },//24
                new Product { ProductId = 26, Name = "Thai green curry paste" },//25
                new Product { ProductId = 27, Name = "Coconut milk" },//26
                new Product { ProductId = 28, Name = "Prawns" },//27
                new Product { ProductId = 29, Name = "Courgetti" },//28
                new Product { ProductId = 30, Name = "Lamb" },//29
                new Product { ProductId = 31, Name = "Onion" },//30
                new Product { ProductId = 32, Name = "Thyme" },//31
                new Product { ProductId = 33, Name = "Red wine" },//32
                new Product { ProductId = 34, Name = "Watercress" },//33
                new Product { ProductId = 35, Name = "Feta" },//34
                new Product { ProductId = 36, Name = "Self-raising flour" },//35
                new Product { ProductId = 37, Name = "Sparkling water" },//36
                new Product { ProductId = 38, Name = "Groundnut oil" }//37
            };

            builder.Entity<Product>().HasData(products);
            builder.Entity<Category>().HasData(categories);

            builder.Entity<Recipe>().HasData(
                    new Recipe
                    {
                        RecipeId = 1,
                        Name = "Roast Chicken with Grapefruit",
                        RecipeImageUrl = "string",
                        Difficulty = Difficulty.Medium,
                        Instruction = "Working over a bowl to collect juice, section grapefruits into suprêmes, cutting away all peel, pith, and membranes. Squeeze remaining skin and membranes into the bowl to extract as much juice as possible.\r\n\r\nPreheat the oven to 375 degrees F (190 degrees C).\r\n\r\nStir together salt and pepper in a small bowl. Slip fingers beneath the skin of the chicken breast and thighs to loosen it from the meat. Rub salt mixture under skin, inside cavity, and over skin. Tuck half the suprêmes and a few parsley sprigs into chicken cavity. Transfer chicken, breast side up, to a rack in a baking dish or a cast-iron skillet.\r\n\r\nTie legs together with kitchen twine; fold wing tips back and tuck under chicken. Halve bacon; drape over breast in a herringbone pattern, overlapping as needed. Drizzle with oil, coating any uncovered skin.\r\n\r\nRoast in the preheated oven for 40 minutes. Pour grapefruit juice over chicken. Continue roasting 35 to 40 minutes or until an instant-read thermometer inserted into thickest parts of thigh and breast registers 170°F. Tent with foil; let rest at least 15 minutes. Discard kitchen twine. Remove and reserve suprêmes from chicken cavity.\r\n\r\nFor sauce, warm cognac in a small stainless-steel or copper (not nonstick) skillet over medium heat for a few seconds until shimmering at the edges. Remove from heat.\r\n\r\nCarefully ignite with a stick lighter or long match. Let burn for 1 minute. Add roasted grapefruit suprêmes, the broth, and half-and-half; heat through. Season to taste with salt and pepper.\r\n\r\nServe chicken on a platter with remaining fresh suprêmes (or extra grapefruit wedges) and parsley sprigs. Spoon warm sauce over carved chicken.",
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                    },
                    new Recipe
                    {
                        RecipeId = 2,
                        Name = "Perfect Sushi Rice",
                        Difficulty = Difficulty.Easy,
                        RecipeImageUrl = "string",
                        Instruction = "Rinse the rice in a strainer or colander under cold running water until the water runs clear.\r\n\r\nCombine rice and water in a saucepan over medium-high heat and bring to a boil. Reduce heat to low, cover, and cook until rice is tender and all water has been absorbed, about 20 minutes. Remove from stove and set aside until cool enough to handle.\r\n\r\nMeanwhile, combine rice vinegar, oil, sugar, and salt in a small saucepan over medium heat. Cook until the sugar has dissolved. Allow to cool, then stir into the cooked rice. While mixture will appear very wet at first, keep stirring and rice will dry as it cools.",
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                    },
                    new Recipe
                    {
                        RecipeId = 3,
                        Name = "Bechamel sause",
                        Difficulty = Difficulty.Easy,
                        RecipeImageUrl = "string",
                        Instruction = "Melt butter in a large saucepan over medium heat. Add flour and whisk into the melted butter until smooth. Cook and stir until flour turns a light, golden, sandy color, about 7 minutes.\r\n\r\nIncrease heat to medium-high and slowly whisk in milk until thickened by the roux. Bring to a gentle simmer, then reduce heat to medium-low and continue simmering until the flour has softened and no longer tastes gritty, 10 to 20 minutes. Season with salt and species.",
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                    },
                    new Recipe
                    {
                        RecipeId = 4,
                        Name = "Smoked salmon & spinach gratin",
                        Difficulty = Difficulty.Easy,
                        RecipeImageUrl = "string",
                        Instruction = "STEP 1\r\nPut the spinach in a really big saucepan (or two saucepans) and add a few tablespoons of water. Cover, set over a medium heat and cook for about 5-8 mins, turning the spinach over every so often, until wilted. Tip it into a colander to drain and allow it to cool (spread it out on a plate to cool it quicker). Take big handfuls of it in your fists and squeeze out the excess water. It’s really important that you do this, otherwise the water will leach out and make the cream watery and green.\r\n\r\nSTEP 2\r\nChop the spinach. Melt the butter in a saucepan and gently toss the spinach in it. Season with pepper and a tiny bit of salt (there’s so much salt in the salmon). Heat the oven to 160C/140C fan/gas 3. Lay the spinach in the bottom of a gratin dish (about 30cm x 20cm), then arrange the salmon fillets on top.\r\n\r\nSTEP 3\r\nHeat the double cream in a small pan, then pour it all over the salmon and spinach. Bake for 35 mins, or until the top is golden and the cream is bubbling.",
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                    },
                    new Recipe
                    {
                        RecipeId = 5,
                        Name = "Pesto & goat's cheese risotto",
                        Difficulty = Difficulty.Easy,
                        RecipeImageUrl = "string",
                        Instruction = "STEP 1\r\nPour a glug of olive oil into a large saucepan. Tip in the rice and fry for 1 min. Add half the stock and cook until absorbed. Add the remaining stock, a ladle at a time, and cook until the rice is al dente, stirring continually, for 20-25 mins.\r\n\r\nSTEP 2\r\nStir through the pesto and half the goat’s cheese. Serve topped with the remaining cheese.",
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                    },
                    new Recipe
                    {
                        RecipeId = 6,
                        Name = "Prawn & coconut soup",
                        Difficulty = Difficulty.Easy,
                        RecipeImageUrl = "string",
                        Instruction = "Heat 1 tsp flavourless oil in a frying pan over a medium heat. Add the curry paste and cook for 1 min. Pour in the coconut milk, then leave to bubble away for a few mins before adding the prawns and courgetti. Cook for 1 min more to warm through, then divide between bowls.",
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                    },
                    new Recipe
                    {
                        RecipeId = 7,
                        Name = "Slow-cooked lamb with onions & thyme",
                        Difficulty = Difficulty.Easy,
                        RecipeImageUrl = "string",
                        Instruction = "STEP 1\r\nFirstly, prepare the lamb. Heat oven to 160C/fan140C/gas 3. Wipe the meat all over and season well. Heat 3 tbsp of olive oil in a large heavy flameproof casserole, add the meat and fry all over on a fairly high heat for about 8 mins, turning until it is evenly well browned. Remove to a plate.\r\n\r\nSTEP 2\r\nThinly slice the onions. Add to the pan and fry for about 10 mins, until softened and tinged with brown. Add a few of the thyme sprigs and cook for a further minute or so. Season with salt and pepper.\r\n\r\nSTEP 3\r\nSit the lamb on top of the onions, then add the wine. Cover tightly. Bake for 3 hrs. You can make to this stage up to 2 days in advance, then reheat for 45 mins.\r\n\r\nSTEP 4\r\nTo finish off, strip the leaves from 2 thyme sprigs and chop them with the parsley. Scatter over before serving.",
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                    },
                    new Recipe
                    {
                        RecipeId = 8,
                        Name = "Citrus salmon salad",
                        Difficulty = Difficulty.Easy,
                        RecipeImageUrl = "string",
                        Instruction = "STEP 1\r\nHeat oven to 200C/180C fan/ gas 6 and roast the salmon for 8 mins. Meanwhile, segment the grapefruit and mix the juices with 2 tbsp extra virgin olive oil to make a dressing.\r\n\r\nSTEP 2\r\nToss the watercress with the grapefruit segments, dressing and feta, and serve with the salmon, flaked into large pieces.",
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                    },
                   new Recipe
                   {
                       RecipeId = 9,
                       Name = "Onion rings",
                       Difficulty = Difficulty.Easy,
                       RecipeImageUrl = "string",
                       Instruction = "STEP 1\r\nUse a fork to steady your onion. Slice the onion into rings about 1cm wide. Remove the skin and separate the rings.\r\n\r\nSTEP 2\r\nHeat the oil to 180C in a heavy-based pan – it should be no more than 1/ 3 full.\r\n\r\nSTEP 3\r\nMeanwhile put the flour and sparkling water in a bowl and season generously. Whisk together to form a batter.\r\n\r\nSTEP 4\r\nCoat a small batch of onion rings in batter. Carefully lower into the hot oil and deep-fry until crisp and golden, about 2 - 3 minutes. Remove with a slotted spoon and place on a piece of kitchen towel to drain. Repeat with the remaining onion and batter.",
                       UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                   }
                );

            List<RecipeCategory> recipeCategories = new List<RecipeCategory>
                    {
                        new RecipeCategory
                        {
                            CategoryId = 4,
                            RecipeId = 1
                        },
                        new RecipeCategory
                        {
                            CategoryId = 11,
                            RecipeId = 1
                        },
                        new RecipeCategory
                        {
                            CategoryId = 5,
                            RecipeId = 2
                        },
                        new RecipeCategory
                        {
                            CategoryId = 2,
                            RecipeId = 3
                        },
                        new RecipeCategory
                        {
                            CategoryId = 13,
                            RecipeId = 4
                        },
                        new RecipeCategory
                        {
                            CategoryId = 2,
                            RecipeId = 5
                        },
                        new RecipeCategory
                        {
                            CategoryId = 14,
                            RecipeId = 6
                        },
                        new RecipeCategory
                        {
                            CategoryId = 4,
                            RecipeId = 7
                        },
                        new RecipeCategory
                        {
                            CategoryId = 3,
                            RecipeId = 8
                        },
                        new RecipeCategory
                        {
                            CategoryId = 4,
                            RecipeId = 9
                        }
                        };

            List<RecipeProduct> recipeProducts = new List<RecipeProduct>
                        {
                        new RecipeProduct
                        {
                            ProductId = 1,
                            Quantity = 3,
                            Unit = Unit.piece,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 2,
                            Quantity = 1,
                            Unit = Unit.tbsp,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 3,
                            Quantity = 1.5,
                            Unit = Unit.tsp,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 4,
                            Quantity = 1,
                            Unit = Unit.piece,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 5,
                            Quantity = 25,
                            Unit = Unit.g,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 6,
                            Quantity = 150,
                            Unit = Unit.g,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 7,
                            Quantity = 1,
                            Unit = Unit.tbsp,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 8,
                            Quantity = 1,
                            Unit = Unit.tbsp,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 9,
                            Quantity = 1,
                            Unit = Unit.tsp,
                            RecipeId = 1
                        },
                        new RecipeProduct
                        {
                            ProductId = 10,
                            Quantity = 400,
                            Unit = Unit.g,
                            RecipeId = 2
                        },
                        new RecipeProduct
                        {
                            ProductId = 11,
                            Quantity = 750,
                            Unit = Unit.g,
                            RecipeId = 2
                        },
                        new RecipeProduct
                        {
                            ProductId = 12,
                            Quantity = 4,
                            Unit = Unit.tbsp,
                            RecipeId = 2
                        },
                        new RecipeProduct
                        {
                            ProductId = 13,
                            Quantity = 1,
                            Unit = Unit.tbsp,
                            RecipeId = 2
                        },
                        new RecipeProduct
                        {
                            ProductId = 14,
                            Quantity = 2,
                            Unit = Unit.tbsp,
                            RecipeId = 2
                        },
                        new RecipeProduct
                        {
                            ProductId = 3,
                            Quantity = 1,
                            Unit = Unit.tsp,
                            RecipeId = 2
                        },
                        new RecipeProduct
                        {
                            ProductId = 15,
                            Quantity = 5,
                            Unit = Unit.tbsp,
                            RecipeId = 3
                        },
                        new RecipeProduct
                        {
                            ProductId = 16,
                            Quantity = 4,
                            Unit = Unit.tbsp,
                            RecipeId = 3
                        },
                        new RecipeProduct
                        {
                            ProductId = 17,
                            Quantity = 300,
                            Unit = Unit.ml,
                            RecipeId = 3
                        },
                        new RecipeProduct
                        {
                            ProductId = 3,
                            Quantity = 1,
                            Unit = Unit.tsp,
                            RecipeId = 3
                        },
                        new RecipeProduct
                        {
                            ProductId = 18,
                            Quantity = 0.25,
                            Unit = Unit.tsp,
                            RecipeId = 3
                        },

                        new RecipeProduct
                        {
                            ProductId = 19,
                            Quantity = 1200,
                            Unit = Unit.g,
                            RecipeId = 4
                        },
                        new RecipeProduct
                        {
                            ProductId = 15,
                            Quantity = 15,
                            Unit = Unit.g,
                            RecipeId = 4
                        },
                        new RecipeProduct
                        {
                            ProductId = 20,
                            Quantity = 1000,
                            Unit = Unit.g,
                            RecipeId = 4
                        },
                        new RecipeProduct
                        {
                            ProductId = 21,
                            Quantity = 300,
                            Unit = Unit.ml,
                            RecipeId = 4
                        },
                        new RecipeProduct
                        {
                            ProductId = 7,
                            Quantity = 20,
                            Unit = Unit.g,
                            RecipeId = 5
                        },
                        new RecipeProduct
                        {
                            ProductId = 22,
                            Quantity = 200,
                            Unit = Unit.g,
                            RecipeId = 5
                        },
                        new RecipeProduct
                        {
                            ProductId = 23,
                            Quantity = 700,
                            Unit = Unit.ml,
                            RecipeId = 5
                        },
                        new RecipeProduct
                        {
                            ProductId = 24,
                            Quantity = 250,
                            Unit = Unit.g,
                            RecipeId = 5
                        },
                        new RecipeProduct
                        {
                            ProductId = 25,
                            Quantity = 100,
                            Unit = Unit.g,
                            RecipeId = 5
                        },
                        new RecipeProduct
                        {
                            ProductId = 26,
                            Quantity = 3,
                            Unit = Unit.tbsp,
                            RecipeId = 6
                        },
                        new RecipeProduct
                        {
                            ProductId = 27,
                            Quantity = 400,
                            Unit = Unit.ml,
                            RecipeId = 6
                        },
                        new RecipeProduct
                        {
                            ProductId = 28,
                            Quantity = 150,
                            Unit = Unit.g,
                            RecipeId = 6
                        },
                        new RecipeProduct
                        {
                            ProductId = 29,
                            Quantity = 250,
                            Unit = Unit.g,
                            RecipeId = 6
                        },
                        new RecipeProduct
                        {
                            ProductId = 30,
                            Quantity = 1250,
                            Unit = Unit.g,
                            RecipeId = 7
                        },
                        new RecipeProduct
                        {
                            ProductId = 31,
                            Quantity = 1000,
                            Unit = Unit.g,
                            RecipeId = 7
                        },
                        new RecipeProduct
                        {
                            ProductId = 32,
                            Quantity = 30,
                            Unit = Unit.g,
                            RecipeId = 7
                        },
                        new RecipeProduct
                        {
                            ProductId = 33,
                            Quantity = 300,
                            Unit = Unit.ml,
                            RecipeId = 7
                        },
                        new RecipeProduct
                        {
                            ProductId = 5,
                            Quantity = 30,
                            Unit = Unit.g,
                            RecipeId = 7
                        },
                        new RecipeProduct
                        {
                            ProductId = 20,
                            Quantity = 2,
                            Unit = Unit.piece,
                            RecipeId = 8
                        },
                        new RecipeProduct
                        {
                            ProductId = 1,
                            Quantity = 1,
                            Unit = Unit.piece,
                            RecipeId = 8
                        },
                        new RecipeProduct
                        {
                            ProductId = 34,
                            Quantity = 100,
                            Unit = Unit.g,
                            RecipeId = 8
                        },
                        new RecipeProduct
                        {
                            ProductId = 35,
                            Quantity = 200,
                            Unit = Unit.g,
                            RecipeId = 8
                        },
                        new RecipeProduct
                        {
                            ProductId = 31,
                            Quantity = 1,
                            Unit = Unit.piece,
                            RecipeId = 9
                        },
                        new RecipeProduct
                        {
                            ProductId = 38,
                            Quantity = 150,
                            Unit = Unit.ml,
                            RecipeId = 9
                        },
                        new RecipeProduct
                        {
                            ProductId = 36,
                            Quantity = 150,
                            Unit = Unit.g,
                            RecipeId = 9
                        },
                        new RecipeProduct
                        {
                            ProductId = 37,
                            Quantity = 180,
                            Unit = Unit.ml,
                            RecipeId = 9
                        }
                        };

            builder.Entity<RecipeProduct>().HasData(recipeProducts);
            builder.Entity<RecipeCategory>().HasData(recipeCategories);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);
            this.SeedRecipes(modelBuilder);

            modelBuilder.Entity<RecipeCategory>()
                .HasKey(x => new { x.RecipeId, x.CategoryId });

            modelBuilder.Entity<RecipeProduct>()
                .HasKey(x => new { x.RecipeId, x.ProductId });

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.User)
                .WithMany(y => y.Comments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.Post)
                .WithMany(y => y.Comments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.User)
                .WithMany(y => y.Posts);

            modelBuilder.Entity<Recipe>()
                .HasOne(x => x.User)
                .WithMany(y => y.Recipes);

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(x => x.Recipe)
                .WithMany(y => y.RecipeCategories);

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(x => x.Category)
                .WithMany(y => y.RecipeCategories);

            modelBuilder.Entity<RecipeProduct>()
                .HasOne(x => x.Recipe)
                .WithMany(y => y.RecipeProducts);

            modelBuilder.Entity<RecipeProduct>()
                .HasOne(x => x.Product)
                .WithMany(y => y.RecipeProducts);

            modelBuilder.Entity<UserProduct>()
                .HasOne(x => x.Product)
                .WithMany(y => y.UserProducts);

            modelBuilder.Entity<UserProduct>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserProducts);
        }
    }
}
