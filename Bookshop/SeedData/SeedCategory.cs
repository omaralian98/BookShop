namespace Bookshop.Data {
    public static class SeedCategory {
        public static void EnsurePopulated(IApplicationBuilder app, IWebHostEnvironment hostEnvironment) {
            ShopDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ShopDbContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            if (!context.Categories.Any()) {
                context.Categories.AddRange(
                    new Category {
                        Name = "Biography",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/Biography.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Fiction",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/Fiction.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Fantasy",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/Fantasy.png".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "History",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Thriller",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Adventure",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Anthology",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Autobiography",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Romance",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Classical",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Folklore",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Self Help",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Comic",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Cooking",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Medical",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Kids",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Sport",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Science",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Programming",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Category {
                        Name = "Technology",
                        Books = new List<Book>(),
                        Image = "/CategoryImages/None.jpg".PathToByteArray(hostEnvironment),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}