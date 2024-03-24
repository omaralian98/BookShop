namespace Bookshop.Interfaces {
    public interface IBook {        
        public IQueryable<Book> Books { get; }
        public bool AddBook(Book book);
        public void RemoveBook(long Id);
        public bool UpdateBook(Book book);
        public bool FindBook(long Id);
        public Book? GetBook(long Id);
        public bool Exists(Book book);
        public Book? GetBookNonTracked(long Id);
    }
}