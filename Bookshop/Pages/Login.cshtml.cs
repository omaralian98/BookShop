namespace Bookshop.Pages {
    public class Login : PageModel {
        private IAccount account;
        [BindProperty]
        public string? Username { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        public Login(IAccount ac) {
            account = ac;
        }
        public IActionResult OnPostLogin() {
            if (Username == null || Password == null || account.Login(Username, Password) == false) {
                return Page();
            }
            HttpContext.Session.SetString("LoginId", account.Accounts.First(x => x.Username == Username 
            && x.Password == Password).Id.ToString());
            return RedirectToAction("Index");
        } 
    }
}