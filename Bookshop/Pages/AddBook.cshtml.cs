
namespace Bookshop.Pages {
    public class AddBook : PageModel {
        public ICategory Category;
        public IBook Book;
        private IAccount account;
        private IWebHostEnvironment hostEnvironment;
        [BindProperty]
        public Book pro { get; set; } = new();
        [BindProperty]
        public IFormFile? pdf { get; set; }
        [BindProperty]
        public IFormFile? coverpage { get; set; }
        [BindProperty]
        public bool[] Catego { get; set; }
        public AddBook(IBook bookrepo, ICategory categoryrepo, IAccount accountrepo, IWebHostEnvironment he) {
            Book = bookrepo;
            hostEnvironment = he;
            Category = categoryrepo;
            account = accountrepo;
        }
        public IActionResult OnGet() {
            long Id = Convert.ToInt64(HttpContext.Session.GetString("LoginId"));
            #pragma warning disable 8600, 8602, 8604
            Account user = account.GetAccount(Id);
            if (HttpContext.Session.GetString("LoginId") == null || user.Role.Name != "Admin") {
                return RedirectToPage("/Error", "Show", new { message = "You don't have permission to access this page",
                 instruction = "Please contact the staff to grant you the required permission"});
            }
            #pragma warning restore 8600, 8602, 8604
            return Page();
        }
        public IActionResult OnPostSave() {
            if (Book.Exists(pro)) {
                return RedirectToPage("/Error", "Show", new { message = "This Book Already exists"});
            }
            pro.Coverpage = coverpage == null ? "/Coverpages/None.png".PathToByteArray(hostEnvironment) 
            : Image.Load(coverpage.OpenReadStream()).ImageToByteArray();
            pro.PDF = pdf == null ? null : pdf.PdfToByteArray();
            if (Category.Categories.Count() != Catego.Length)
                return RedirectToPage("/Error", "Show", new { message = Category.Categories.Count()});
            pro.Categories = new List<Category>();
            for (int i = 0; i < Catego.Length; i++) {
                if (Catego[i]) {
                    pro.Categories.Add(Category.GetCategory(Category.Categories.Skip(i).First().Id));
                }
            }
            Book.AddBook(pro);
            return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Books"});
        }
    }
}