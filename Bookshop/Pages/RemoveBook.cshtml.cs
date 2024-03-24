namespace Bookshop.Pages {
    public class RemoveBook : PageModel {
        private IBook book;
        private IAccount account;
        public RemoveBook(IBook bo, IAccount ac) {
            book = bo;
            account = ac;
        }
        public IActionResult OnGet(long id) {
            long IDS = Convert.ToInt64(HttpContext.Session.GetString("LoginId"));
            #pragma warning disable 8600, 8602, 8604
            Account user = account.GetAccount(IDS);
            if (HttpContext.Session.GetString("LoginId") == null || user.Role.Name != "Admin") {
                return RedirectToPage("/Error", "Show", new { message = "You don't have permission to access this page",
                 instruction = "Please contact the staff to grant you the required permission"});
            }
            #pragma warning restore 8600, 8602, 8604
            book.RemoveBook(id);
            return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Books"});
        }
    }
}