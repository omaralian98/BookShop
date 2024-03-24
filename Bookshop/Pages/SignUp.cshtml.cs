namespace Bookshop.Pages {
    public class SignUp : PageModel {
        public IAccount account;
        public IRole role;
        private IWebHostEnvironment Environment;
        [BindProperty]
        public Account user { get; set; } = new();
        [BindProperty]
        public IFormFile? Avatar { get; set; }
        public SignUp(IAccount ac, IRole ro, IWebHostEnvironment environment){
            account = ac;
            role = ro;
            Environment = environment;
        } 

        public IActionResult OnPostSave() {
            if (account.Exists(user) == true) {
                return RedirectToPage("/Error", "Show", new { message = "This Account Already exists"});
            }
            user.Avatar = Avatar == null ?  "/AccountImage/None.jpg".PathToByteArray(Environment) 
            : Image.Load(Avatar.OpenReadStream()).ImageToByteArray();
            user.Role = role.GetRole(2);
            account.AddAccount(user);
            HttpContext.Session.SetString("LoginId", user.Id.ToString());
            return new RedirectToActionResult("Index", "Home", "");
        }
    }
}