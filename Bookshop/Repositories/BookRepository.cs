namespace Bookshop.Repositories {
    public class BookRepository : IBook {
        private ShopDbContext context;
        public BookRepository(ShopDbContext cont) {
            context = cont;
        }
        public IQueryable<Book> Books => context.Books.Include(x => x.Categories).OrderBy(x => x.Id);
        public bool AddBook(Book book) {
            context.Books.Add(book);
            context.SaveChanges();
            return true;
        }
        public void RemoveBook(long Id) {
            context.Books.Remove(context.Books.First(x => x.Id == Id));
            context.SaveChanges();
        }
        public bool UpdateBook(Book book) {
            context.Books.Add(book);
            context.SaveChangesWithIdentityInsert<Book>();
            return true;
        }
        public bool FindBook(long Id) {
            return Books.Select(x => x.Id == Id).Count() > 0;
        }
        public Book? GetBook(long Id) {
            return Books.FirstOrDefault(x => x.Id == Id);
        }
        public bool Exists(Book book) {
            if (Books.Any(x => x.Title == book.Title && x.Author == book.Author)) return true;
            return false;
        }
        public Book? GetBookNonTracked(long Id) {
            return context.Books.AsNoTracking().Include(x => x.Categories).FirstOrDefault(x => x.Id == Id);
        }
    }
}