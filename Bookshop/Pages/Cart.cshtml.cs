using System;
namespace Bookshop.Pages {
    public class CartModel : PageModel {
        private IBook book;
        public CartModel(IBook bo, Cart cartService) {
            book = bo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public IActionResult OnGet(string Ids, string? url = null) {
            string[]? values = new string[1];
            try {
                values = Ids.Trim().Split(",");
            } 
            catch { 
                if (url == null)
                    return Page(); 
            }
            try {
                foreach (string it in values) {
                    long Id = int.Parse(it.Trim());
                    Book? bok = book.GetBook(Id);
                    if (bok != null) {
                        Cart.AddItem(bok, 1);
                    }
                }
                if (url == null)
                    return Page();
            }
            catch {}
            if (url == null)
                return RedirectToPage("Error");
            return Redirect(url);
        }

        public IActionResult OnPostRemove(long Id) {
            try {Cart.RemoveLine(Cart.Lines.First(x => x.Book.Id == Id).Book);} catch{}
            return Page();
        }
        public IActionResult OnPostMinus(long Id) {
            try {Cart.Minus(Cart.Lines.First(x => x.Book.Id == Id).Book);} catch{}
            return Page();
        }
        public IActionResult OnPostPlus(long Id) {
            try{Cart.Plus(Cart.Lines.First(x => x.Book.Id == Id).Book);} catch{}
            return Page();
        }
    }
}