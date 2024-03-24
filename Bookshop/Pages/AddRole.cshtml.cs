namespace Bookshop.Pages {
    public class AddRole : PageModel {
        private IRole Role;
        private IAccount account;
        public AddRole(IRole ro, IAccount ac) {
            Role = ro;
            account = ac;
        }
        [BindProperty]
        public string role { get; set; } = "New Role";
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
            if (Role.Exists(role)) {
                return RedirectToPage("/Error", "Show", new { message = "This Role Already exists"});
            }
            Role.AddRole(role);
            return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Roles"});
        }
    }
}