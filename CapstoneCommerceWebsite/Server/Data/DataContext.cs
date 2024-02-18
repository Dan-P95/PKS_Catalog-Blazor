namespace PKS_Catalog.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemVariant>().HasKey(p => new { p.ItemId, p.ItemGroupId });

            modelBuilder
                .Entity<ItemGroup>()
                .HasData(
                    new ItemGroup { Id = 1, Name = "Default" },
                    new ItemGroup { Id = 2, Name = "156cm" },
                    new ItemGroup { Id = 3, Name = "158cm" },
                    new ItemGroup { Id = 4, Name = "160cm" },
                    new ItemGroup { Id = 5, Name = "162cm" },
                    new ItemGroup { Id = 6, Name = "Small" },
                    new ItemGroup { Id = 7, Name = "Medium" },
                    new ItemGroup { Id = 8, Name = "Large" }
                );

            modelBuilder
                .Entity<ItemVariant>()
                .HasData(
                    new ItemVariant
                    {
                        ItemId = 1,
                        ItemGroupId = 2,
                        Price = 249.99m,
                        OriginalPrice = 300.00m
                    },
                    new ItemVariant
                    {
                        ItemId = 1,
                        ItemGroupId = 3,
                        Price = 129.49m,
                        OriginalPrice = 280.80m
                    },
                    new ItemVariant
                    {
                        ItemId = 1,
                        ItemGroupId = 4,
                        Price = 650.19m,
                        OriginalPrice = 1243.22m
                    },
                    new ItemVariant
                    {
                        ItemId = 4,
                        ItemGroupId = 6,
                        Price = 119.99m,
                        OriginalPrice = 320.00m
                    },
                    new ItemVariant
                    {
                        ItemId = 4,
                        ItemGroupId = 7,
                        Price = 229.99m,
                        OriginalPrice = 300.00m
                    },
                    new ItemVariant
                    {
                        ItemId = 4,
                        ItemGroupId = 8,
                        Price = 49.99m,
                        OriginalPrice = 250.00m
                    },
                    new ItemVariant
                    {
                        ItemId = 7,
                        ItemGroupId = 6,
                        Price = 249.99m,
                        OriginalPrice = 300.00m
                    },
                    new ItemVariant
                    {
                        ItemId = 7,
                        ItemGroupId = 7,
                        Price = 79.99m,
                        OriginalPrice = 100.00m
                    },
                    new ItemVariant
                    {
                        ItemId = 7,
                        ItemGroupId = 8,
                        Price = 149.99m,
                    }
                );
            modelBuilder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        UserName = "test",
                        Password = "password",
                        CreatedDate = DateTime.Now,
                        Id = 1
                    }
                );

            modelBuilder
                .Entity<Group>()
                .HasData(
                    new Group
                    {
                        Id = 1,
                        Name = "Snowboards",
                        Url = "snowboards"
                    },
                    new Group
                    {
                        Id = 2,
                        Name = "Bindings",
                        Url = "bindings"
                    },
                    new Group
                    {
                        Id = 3,
                        Name = "Soft Goods",
                        Url = "soft-goods"
                    }
                );

            modelBuilder
                .Entity<Item>()
                .HasData(
                    new Item
                    {
                        Id = 1,
                        Name = "Shredder",
                        Description =
                            "Route SL comes with all the same qualities as the Route but with upgraded construction.The Route SL board has a response plus honeycomb core with poplar, paulownia, and honeycomb in targeted areas for weight reduction. Add carbon reply laminate and additional precured impact plates for increased strength through the binding and tour hardware zones. The oversized shovel nose and tapered inverted tail tackles powder to hardpack. Finished with a high end sintered base for setting the pace and speeding down the face. For a powder board quiver killer with the best of the best construction look no further than the Carbon Route SL.",
                        ImageUrl =
                            "https://images.unsplash.com/photo-1584890131712-18ee8e3ed49c?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8c25vd2JvYXJkfGVufDB8fDB8fHwwg",

                        Brand = "K2",
                        GroupId = 1
                    },
                    new Item
                    {
                        Id = 2,
                        Name = "Noodle",
                        Description =
                            "The Foundation was designed to deliver amazing value and is the ideal platform to comfortably cruise and progress your snowboarding across the whole resort. Built on Arbor''s System Rocker platform to provide an incredibly forgiving, easy to control, catch-free experience. The Foundation is perfect for improving your turns and building confidence all over the mountain.",
                        ImageUrl =
                            "https://images.unsplash.com/photo-1478700485868-972b69dc3fc4?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8c25vd2JvYXJkfGVufDB8fDB8fHww",

                        Brand = "K2",
                        GroupId = 1
                    },
                    new Item
                    {
                        Id = 3,
                        Name = "Ice Bomb",
                        Description =
                            "Versatile, forgiving and fun, the men''s Rossignol Evader Snowboard is an all-mountain ride for building skills and expanding your range. The right combination of rocker and soft flex makes for a maneuverable, catch-free ride that lets you push into new terrain and explore the mountain in any snow conditions.\r\n\r\nEffortless Mobility and Float - AmpTek Auto-Turn Rocker provides incredible maneuverability, catch-free feel and instant float\r\n\r\nStability and Control - Directional All-Mountain flex provides increased control on back foot and high stability for smooth turn initiation\r\n\r\nAll-Mountain Progression and Forgiveness - Softer flex offers ease of ride, gentle grip and superior shock absorption\r\n\r\nSustainability - 100% of Rossignol''s wood snowboard cores originate from sustainably-harvested forests",
                        ImageUrl =
                            "https://images.unsplash.com/photo-1518085050105-3c33befa5442?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8c25vd2JvYXJkfGVufDB8fDB8fHww",

                        Brand = "K2",
                        GroupId = 1
                    },
                    new Item
                    {
                        Id = 4,
                        Name = "K2 Cinch TS",
                        Description =
                            "Waste no time strapping in and get to the bottom before everyone else. The K2 Cinch TS is quick on the draw and our most premium and responsive convenience binding.\r\n\r\nThis snowboard binding harnesses the tech found on our top-end premium models, coming together into a truly deluxe binding that’s fully equipped with all the bells and whistles. Our customizable Tripod™ Chassis uses interchangeable urethane dampers (“pods”) under the base of the binding to fine tune the medial and lateral flex for board response that’s uniquely yours. The chassis also features a 3º cant that puts riders into the anatomically correct and balanced riding position.\r\n\r\nThe sturdy and lightweight AT Nylon Highback flips down toward the snow when you’re ready to slide in and locks in with a pull of a lever when it’s time to cruise thanks to our time-tested Cinch™ Technology. The Bender™ 3D Ankle Strap and PerfectFit™ Toe Strap provide a secure and highly adjustable fit for sending it all over the mountain and in any snow condition.\r\n\r\nFor premium performance, ultra quick strapping, and even quicker lapping, the K2 Cinch is an all-mountain binding that shatters the convenience binding mold.",
                        ImageUrl =
                            "https://plus.unsplash.com/premium_photo-1707974038665-1ccb4bec6c2e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c25vd2JvYXJkJTIwYmluZGluZ3N8ZW58MHx8MHx8fDA%3D",

                        Brand = "K2",
                        GroupId = 2
                    },
                    new Item
                    {
                        Id = 5,
                        Name = "Flux Nation",
                        Description =
                            "The Nation is a park specific binding that is softer, lighter and more forgiving than the award winning Truce binding. It features lightweight and pressure-point free injected straps for superior boot hold and flex as well as 3 degree canted footbeds for better hip alignment. Think of it as a suped-up version of the Truce with all the same tool free adjustments, cast aluminium buckles and EVA padding, but with a softer flex for better slow speed maneuverability in the park.",
                        ImageUrl =
                            "https://images.unsplash.com/photo-1496887515187-f364d230ab6c?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fHNub3dib2FyZCUyMGJpbmRpbmdzfGVufDB8fDB8fHww",

                        Brand = "Fix",
                        GroupId = 2
                    },
                    new Item
                    {
                        Id = 6,
                        Name = "Flux DS",
                        Description =
                            "Versatile, forgiving and fun, the men''s Rossignol Evader Snowboard is an all-mountain ride for building skills and expanding your range. The right combination of rocker and soft flex makes for a maneuverable, catch-free ride that lets you push into new terrain and explore the mountain in any snow conditions.\r\n\r\nEffortless Mobility and Float - AmpTek Auto-Turn Rocker provides incredible maneuverability, catch-free feel and instant float\r\n\r\nStability and Control - Directional All-Mountain flex provides increased control on back foot and high stability for smooth turn initiation\r\n\r\nAll-Mountain Progression and Forgiveness - Softer flex offers ease of ride, gentle grip and superior shock absorption\r\n\r\nSustainability - 100% of Rossignol''s wood snowboard cores originate from sustainably-harvested forests",
                        ImageUrl = "https://images.the-house.com/flux-ds-bindings-team-23-0.jpg",
                        Brand = "Flux",
                        GroupId = 2
                    },
                    new Item
                    {
                        Id = 7,
                        Name = "Colcom DUA Gore-Tex Snowboard Jacket",
                        Description =
                            "A Gore-Tex shell jacket with subtle styling and a sleek silhouette helps keep the wind out and the warmth in, with plenty of room to layer. Fully taped seams and patented Zip Tech® mean you're fully sealed from the elements. The two-layer outer sheds precip like it's going out of style. This jacket, however, is not.",
                        ImageUrl =
                            "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8amFja2V0fGVufDB8fDB8fHww",
                        Brand = "Volcom",
                        GroupId = 3
                    },
                    new Item
                    {
                        Id = 8,
                        Name = "Evol Field Snowboard Jacket",
                        Description =
                            "Evol Field jacket is the standard for jackets, classic inspired style with a twist of pop, waterproofing, and style. The Field jacket is 10k waterproof/breathable with removable hood, snow gaiters, light insulation, venting, on a regular fit silhouette. Built to shelter you in the streets or mountains from the winter elements.",
                        ImageUrl =
                            "https://images.unsplash.com/photo-1611312449408-fcece27cdbb7?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8amFja2V0fGVufDB8fDB8fHwwg",
                        Brand = "Evol Field",
                        GroupId = 3
                    },
                    new Item
                    {
                        Id = 9,
                        Name = "THE NORTH FACE PRINTED DRAGLINE SNOWBOARD JACKET",
                        Description =
                            "75D x 160D 216 g/m² DryVent™ 3L—100% recycled polyester ripstop with non-PFC durable water-repellent (non-PFC DWR) finish\r\nWaterproof, breathable, seam-sealed DryVent™ 3L shell with a non-PFC DWR finish helps keep you dry\r\nAttached, fully adjustable, helmet-compatible hood\r\n#5 YKK® AquaGuard® VISLON® center front zip\r\nTwo chest pockets with #5 YKK® AquaGuard® VISLON® zips\r\nMedia port in right chest pocket\r\nSecure-zip hand pockets with a snap-closure flap\r\nSecure-zip pass pocket with a goggle wipe above left cuff\r\nTwo internal, mesh drop pockets",
                        ImageUrl =
                            "https://images.unsplash.com/photo-1557418669-db3f781a58c0?q=80&w=1994&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Brand = "The North Face",
                        GroupId = 3
                    }
                );
        }

        //create table in database using code below
        public DbSet<Item> Items { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemVariant> ItemVariants { get; set; }

        // THIS SHOULD BE PLURAL
        public DbSet<User> User { get; set; }
    }
}
