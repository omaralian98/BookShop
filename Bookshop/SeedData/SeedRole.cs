namespace Bookshop.Data {
    public static class SeedRole {
        public static void EnsurePopulated(IApplicationBuilder app) {
            ShopDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ShopDbContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            if (!context.Roles.Any()) {
                context.Roles.AddRange(
                    new Role {
                        Name = "Admin",
                        Accounts = new List<Account>()
                    },
                    new Role {
                        Name = "User",
                        Accounts = new List<Account>()
                    } 
                );
                context.SaveChanges();
            }
        }
    }
}