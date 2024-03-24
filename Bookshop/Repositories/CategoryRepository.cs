namespace Bookshop.Repositories {
    public class CategoryRepository : ICategory {
        private ShopDbContext context;
        public CategoryRepository(ShopDbContext cont) {
            context = cont;
        }
        public IQueryable<Category> Categories => context.Categories.Include(x => x.Books);
        public bool AddCategory(Category category) {
            context.Categories.Add(category);
            context.SaveChanges();
            return true;
        }
        public void RemoveCategory(int Id) {
            context.Categories.Remove(context.Categories.First(x => x.Id == Id));
            context.SaveChanges();
        }
        public void RemoveCategory(string name) {
            #pragma warning disable 8602
            try { RemoveCategory(GetCategory(name).Id); } catch {}
            #pragma warning restore 8602
        }
        public bool UpdateCategory(Category category) {
            context.Categories.Add(category);
            context.SaveChangesWithIdentityInsert<Category>();
            return true;
        }
        public bool FindCategory(int Id) {
            return Categories.Select(x => x.Id == Id).Count() > 0;
        }
        public Category? GetCategory(int Id) {
            return Categories.FirstOrDefault(x => x.Id == Id);
        }
        public Category? GetCategory(string name) {
            return Categories.FirstOrDefault(x => x.Name == name);
        }
        public bool Exists(Category category) {
            if (Categories.Any(x => x.Name == category.Name)) return true;
            return false;
        }
    }
}