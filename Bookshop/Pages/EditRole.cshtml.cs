namespace Bookshop.Pages {
    public class EditRole : PageModel {
        private IRole Role;
        private IAccount account;
        [BindProperty]
        public Role? role { get; set; }
        public EditRole(IRole ro) {
            Role = ro;
        }
        public IActionResult OnGet(int id) {
            #pragma warning disable 8601, 8602
            role = Role.GetRole(id);
            if (role == null) return RedirectToPage("/Error", "Show", new { message = "This Role Doesn't exist"});
            Role.RemoveRole(id);
            long Id = Convert.ToInt64(HttpContext.Session.GetString("LoginId"));
            Account tempuser = account.GetAccount(Id);
            if (HttpContext.Session.GetString("LoginId") == null || tempuser.Role.Name != "Admin") {
                return RedirectToPage("/Error", "Show", new { message = "You don't have permission to access this page",
                 instruction = "Please contact the staff to grant you the required permission"});
            }
            #pragma warning restore 8601, 8602
            return Page();
        }
        public IActionResult OnPostUpdate() {
            if (role != null) {
                if (Role.UpdateRole(role)) {
                    return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Roles"});
                }
            }
            return RedirectToAction("Error");
        }
    }
}