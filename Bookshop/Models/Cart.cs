namespace Bookshop.Models {
    public class Cart {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Book book, int quantity) {
            CartLine? line = Lines.FirstOrDefault(x => x.Book.Id == book.Id);
            if (line == null) {
                Lines.Add(new CartLine {
                    Book = book,
                    Quantity = quantity
                });
            } 
            else {
                line.Quantity += quantity;
            }
        }
        public virtual void Minus(Book Book) {
            CartLine? line = Lines.FirstOrDefault(x => x.Book.Id == Book.Id);
            if (line != null) {
                if (line.Quantity == 1)
                    RemoveLine(Book);
                else
                    line.Quantity -= 1;
            }
        }
        public virtual void RemoveLine(Book Book) => Lines.RemoveAll(x => x.Book.Id == Book.Id);
        public virtual void Plus(Book Book) => AddItem(Book, 1);
        public virtual decimal ComputeTotalValue() => Lines.Sum(x => x.Book.Price * x.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine {
        public int CartLineID { get; set; }
        public Book Book { get; set; } = new();
        public int Quantity { get; set; }
    }
}