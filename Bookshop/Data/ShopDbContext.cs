using System.Reflection;
namespace Bookshop.Data {
    public class ShopDbContext : DbContext {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) {}

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Settings> Settings => Set<Settings>();
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Book>().HasMany(x => x.Categories).WithMany(x => x.Books);
            modelBuilder.Entity<Account>().HasOne(x => x.Role).WithMany(x => x.Accounts);
            modelBuilder.Entity<Settings>().HasData(
                new Settings {
                    Id = 1,
                    BookPerPage = 6
                }
            );
        }
    }
    public static class IdentityHelp {
        public static void EnableIdentityInsert<T>(this ShopDbContext context) => SetIdentityInsert<T>(context, true);
        public static void DisableIdentityInsert<T>(this ShopDbContext context) => SetIdentityInsert<T>(context, false);

        private static void SetIdentityInsert<T>(ShopDbContext context, bool enable) {
            var entityType = context.Model.FindEntityType(typeof(T));
            var value = enable ? "ON" : "OFF";
            context.Database.ExecuteSqlRaw(
                $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}"
            );
        }

        public static void SaveChangesWithIdentityInsert<T>(this ShopDbContext context) {
            using var transaction = context.Database.BeginTransaction();
            context.EnableIdentityInsert<T>();
            context.SaveChanges();
            context.DisableIdentityInsert<T>();
            transaction.Commit();
        }
    }
}
