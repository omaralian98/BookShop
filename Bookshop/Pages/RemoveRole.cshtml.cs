namespace Bookshop.Pages {
    public class RemoveRole : PageModel {
        private IRole cate;
        private IAccount account;
        public RemoveRole(IRole ro, IAccount ac) {
            cate = ro;
            account = ac;
        }
        public IActionResult OnGet(int Id) {
            long IDS = Convert.ToInt64(HttpContext.Session.GetString("LoginId"));
            #pragma warning disable 8600, 8602, 8604
            Account user = account.GetAccount(IDS);
            if (HttpContext.Session.GetString("LoginId") == null || user.Role.Name != "Admin") {
                return RedirectToPage("/Error", "Show", new { message = "You don't have permission to access this page",
                 instruction = "Please contact the staff to grant you the required permission"});
            }
            #pragma warning restore 8600, 8602, 8604
            cate.RemoveRole(Id);
            return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Roles"});
        }
    }
}