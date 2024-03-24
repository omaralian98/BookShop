namespace Bookshop.Pages {
    public class AddCategory : PageModel {
        private ICategory cate;
        private IAccount account;
        private IWebHostEnvironment Environment;
        [BindProperty]
        public Category category { get; set; } = new();
        [BindProperty]
        public IFormFile? image { get; set; }
        public AddCategory(IAccount IAcco, ICategory ca, IWebHostEnvironment environment) {
            cate = ca;
            Environment = environment;
            account = IAcco;
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
        public IActionResult OnPostAdd() {
            if (cate.Exists(category)) {
                return RedirectToPage("/Error", "Show", new { message = "This Category Already exists"});
            }
            category.Image = image == null ? "/CategoryImages/None.jpg".PathToByteArray(Environment)  
            : Image.Load(image.OpenReadStream()).ImageToByteArray();
            cate.AddCategory(category);
            return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Categories"});
        }
    }
}