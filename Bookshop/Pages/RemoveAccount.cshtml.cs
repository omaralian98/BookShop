namespace Bookshop.Pages {
    public class RemoveAccount : PageModel {
        private IAccount account;
        public RemoveAccount(IAccount ac) {
            account = ac;
        }
        public IActionResult OnGet(long id) {
            long Id = Convert.ToInt64(HttpContext.Session.GetString("LoginId"));
            #pragma warning disable 8600, 8602, 8604
            Account user = account.GetAccount(Id);
            if (HttpContext.Session.GetString("LoginId") == null || user.Role.Name != "Admin") {
                return RedirectToPage("/Error", "Show", new { message = "You don't have permission to access this page",
                 instruction = "Please contact the staff to grant you the required permission"});
            }
            #pragma warning restore 8600, 8602, 8604
            account.RemoveAccount(id);
            return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Accounts"});
        }
    }
}