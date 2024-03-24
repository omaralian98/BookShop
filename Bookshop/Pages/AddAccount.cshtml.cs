namespace Bookshop.Pages {
    public class AddAccount : PageModel {
        public IAccount account;
        public IRole role;
        private IWebHostEnvironment Environment;
        [BindProperty]
        public Account user { get; set; } = new();
        [BindProperty]
        public int RoleId { get; set; }
        [BindProperty]
        public IFormFile? Avatar { get; set; }
        public AddAccount(IAccount ac, IRole ro, IWebHostEnvironment environment){
            account = ac;
            role = ro;
            Environment = environment;
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
        public IActionResult OnPostSave() {
            if (account.Exists(user) == true) {
                return RedirectToPage("/Error", "Show", new { message = "This Account Already exists"});
            }
            user.Avatar = Avatar == null ?  "/AccountImage/None.jpg".PathToByteArray(Environment) 
            : Image.Load(Avatar.OpenReadStream()).ImageToByteArray();
            user.Role = role.GetRole(RoleId);
            account.AddAccount(user);
            return new RedirectToPageResult("/Dashboard", "Fet", new {a = "Accounts"});
        }
    }
}