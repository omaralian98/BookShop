namespace Bookshop.Data {
    public static class SeedAccount {
        public static void EnsurePopulated(IApplicationBuilder app, IWebHostEnvironment hostEnvironment) {
            ShopDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ShopDbContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            if (!context.Accounts.Any()) {
                context.Accounts.AddRange(
                    new Account {
                        Username = "Admin",
                        Password = "123",
                        Role = context.Roles.FirstOrDefault(x => x.Name == "Admin"),
                        Avatar = "/AccountImage/None.jpg".PathToByteArray(hostEnvironment),
                    },
                    new Account {
                        Username = "omar",
                        Password = "aqwe1234",
                        Avatar = "/AccountImage/None.jpg".PathToByteArray(hostEnvironment),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}