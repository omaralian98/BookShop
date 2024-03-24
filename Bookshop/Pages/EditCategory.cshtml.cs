namespace Bookshop.Pages {
    public class EditCategory : PageModel {
        private ICategory Category;
        private IAccount account;
        [BindProperty]
        public Category? category { get; set; }
        [BindProperty]
        public IFormFile? image { get; set; }
        [BindProperty]
        public string? data { get; set; }
        public EditCategory(ICategory ro, IAccount ac) {
            Category = ro;
            account = ac;
        }
        public IActionResult OnGet(int id) {
            #pragma warning disable 8601, 8602, 8604
            category = Category.GetCategory(id);
            if (category == null) return RedirectToPage("/Error", "Show", new { message = "This Category Doesn't exist"});
            Category.RemoveCategory(id);
            data = category.Image == null ? null : Convert.ToBase64String(category.Image);
                    long Id = Convert.ToInt64(HttpContext.Session.GetString("LoginId"));
            Account tempuser = account.GetAccount(Id);
            if (HttpContext.Session.GetString("LoginId") == null || tempuser.Role.Name != "Admin") {
                return RedirectToPage("/Error", "Show", new { message = "You don't have permission to access this page",
                 instruction = "Please contact the staff to grant you the required permission"});
            }
            #pragma warning restore 8601, 8602, 8604
            return Page();
        }
        public IActionResult OnPostUpdate() {
            if (category != null) {
                if (data != null) {
                    category.Image = image == null ? Convert.FromBase64String(data) : Image.Load(image.OpenReadStream()).ImageToByteArray();
                }
                if (Category.UpdateCategory(category)) {
                    return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Categories"});
                }
            }
            return RedirectToAction("Error");
        }
    }
}