namespace Bookshop.Interfaces {
    public interface ICategory {
        public IQueryable<Category> Categories { get; }
        public bool AddCategory(Category category);
        public void RemoveCategory(int Id);
        public void RemoveCategory(string name);
        public bool UpdateCategory(Category category);
        public bool FindCategory(int Id);
        public Category? GetCategory(int Id);
        public Category? GetCategory(string name);
        public bool Exists(Category category);
    }
}