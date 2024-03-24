namespace Bookshop.Pages {
    public class EditBook : PageModel {
        public IBook Book;
        private IAccount account;
        public ICategory Category;
        [BindProperty]
        public Book? pro { get; set; }
        [BindProperty]
        public int catagoryId { get; set; }
        [BindProperty]
        public IFormFile? coverpage { get; set; }
        [BindProperty]
        public IFormFile? pdf { get; set; }
        [BindProperty]
        public string data { get; set; } = string.Empty;
        [BindProperty]
        public string pdfdata { get; set; } = string.Empty;
        [BindProperty]
        public bool[] Catego { get; set; }
        public int[] indexes { get; set; }
        public EditBook(IAccount ac, IBook bookrepo, ICategory categoryrepo ) {
            Book = bookrepo;
            Category = categoryrepo;
            account = ac;
        }
        public IActionResult OnGet(long id) {
            #pragma warning disable 8600, 8601, 8602, 8604
            pro = Book.GetBookNonTracked(id);
            Book.RemoveBook(id);
            if (pro == null) return RedirectToPage("/Error", "Show", new { message = "This Book Doesn't exist"});
            data = Convert.ToBase64String(pro.Coverpage);
            pdfdata = pro.PDF == null ? null : Convert.ToBase64String(pro.PDF);
            Catego = new bool[Category.Categories.Count()];
            for (int i = 0; i < pro.Categories.Count; i++) {
                int index = Category.Categories.ToList().FindIndex(x => x.Id == pro.Categories[i].Id);
                Catego[index] = true;
            }
            long Id = Convert.ToInt64(HttpContext.Session.GetString("LoginId"));
            Account tempuser = account.GetAccount(Id);
            if (HttpContext.Session.GetString("LoginId") == null || tempuser.Role.Name != "Admin") {
                return RedirectToPage("/Error", "Show", new { message = "You don't have permission to access this page",
                 instruction = "Please contact the staff to grant you the required permission"});
            }
            #pragma warning restore 8600, 8601, 8602, 8604
            return Page();
        }
        public IActionResult OnPostUpdate() {
            if (pro != null) {
                pro.Coverpage = coverpage == null ? Convert.FromBase64String(data) 
                : Image.Load(coverpage.OpenReadStream()).ImageToByteArray();
                pro.PDF = pdf == null ? pdfdata == null ? null : Convert.FromBase64String(pdfdata) : pdf.PdfToByteArray();
                pro.Categories = new List<Category>();
                for (int i = 0; i < Catego.Length; i++) {
                    if (Catego[i]) {
                        pro.Categories.Add(Category.GetCategory(Category.Categories.Skip(i).First().Id));
                    }
                }
                if(Book.UpdateBook(pro)) {
                    return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Books"});
                }
            }
            return RedirectToAction("Error");
        }
    }
}