namespace Bookshop.Pages {
    public class EditAccount : PageModel {
        private IAccount account;
        public IRole role;
        [BindProperty]
        public Account? user { get; set; }
        [BindProperty]
        public int RoleId { get; set; }
        [BindProperty]
        public IFormFile? Avatar { get; set; }
        [BindProperty]
        public string data { get; set; } = string.Empty;
        public EditAccount(IAccount ac, IRole ro) {
            account = ac;
            role = ro;
        }
        public IActionResult OnGet(long id) {
            #pragma warning disable 8600, 8601, 8602, 8604
            user = account.GetAccount(id);
            if (user == null) return RedirectToPage("/Error", "Show", new { message = "This Account Doesn't exist"});
            account.RemoveAccount(id);
            RoleId = user.Role == null ? 0 : user.Role.Id;
            data = Convert.ToBase64String(user.Avatar);
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
            if (user != null) {
                if (RoleId != 0) user.Role = role.GetRole(RoleId);
                user.Avatar = Avatar == null ? Convert.FromBase64String(data) 
                : Image.Load(Avatar.OpenReadStream()).ImageToByteArray();
                if (account.UpdateAccount(user)) {
                    return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Accounts"});
                }
            }
            return RedirectToAction("Error");
        }
    }
}