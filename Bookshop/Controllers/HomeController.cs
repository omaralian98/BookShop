namespace Bookshop.Controllers {
    public class HomeController : Controller
    {
        private IAccount Account;
        private IBook Book;
        private ICategory Category;
        private IRole Role;
        private int BookPerPage { get; set; }
        public HomeController(IAccount accountrepo, IBook bookrepo, ICategory ca, IRole ro, ISettings sett)
        {
            Account = accountrepo;
            Book = bookrepo;
            Category = ca;
            Role = ro;
            BookPerPage = sett.GetBookPerPage();
        }

        public IActionResult Index(string Category = "None")
        {
            Category? test =  this.Category.GetCategory(Category);
            ViewBag.CategoryName = test == null ? "None" : test.Name;
            return View(Book);
        }
        
        public IActionResult Shop(string Category = "None", int Page = 1) {
            #pragma warning disable 8604
            Category? test =  this.Category.GetCategory(Category);
            ViewBag.CategoryName = test == null ? "None" : test.Name;
            string cat = test == null ? "None" : test.Name;
            IQueryable<Book> books = cat != "None" ? Book.Books
                .Where(x => x.Categories.Any(y => y.Name == cat)) : Book.Books;
            int total = Math.Max((int)Math.Ceiling((decimal)books.Count()/BookPerPage), 1); 
            if (Page > total)
                Page = total;
            Page = Math.Max(Page, 1);
            books = cat != "None" ? Book.Books
                .Where(x => x.Categories.Any(y => y.Name == cat)).Skip((Page - 1) * BookPerPage)
                .Take(BookPerPage) : Book.Books.Skip((Page - 1) * BookPerPage).Take(BookPerPage);
            return View(new PreviewBooks {
                books = books.ToList(),
                PreviousPage = Page - 1,
                CurrentPage = Page,
                NextPage = Page + 1,
                TotalPages = total,
            });
            #pragma warning restore 8604
        }
        public IActionResult Accounts() {
            return PartialView("Accounts", Account);
        }
        public IActionResult Preview(long Id) {
            Book? bok = Book.GetBook(Id);
            if (bok == null)
            return RedirectToPage("/Error");
            ViewBag.Id = Id;
            return View(bok);
        }
        public IActionResult Download(long Id)
        {
            Book? bok = Book.GetBook(Id);
            if (bok == null || bok.PDF == null)
            return RedirectToPage("/Error");
            return File(bok.PDF, "application/pdf", bok.Title + ".pdf");
        }
    }
}