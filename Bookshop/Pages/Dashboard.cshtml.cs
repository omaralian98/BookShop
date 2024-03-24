namespace Bookshop.Pages
{
    public class Dashboard : PageModel {
        public IAccount Account;
        public IBook Book;
        public ICategory Category;
        public IRole Role;
        public IOrder Order;
        public string? render { get; set; }
        public string? ImageData { get; set; }
        public Dashboard(IAccount iac, IBook ibo, ICategory ica, IRole iro, IOrder ior) {
            Account = iac;
            Book = ibo;
            Category = ica;
            Role = iro;
            Order = ior;
        }
        public IActionResult OnGet(string a) {
            long Id = Convert.ToInt64(HttpContext.Session.GetString("LoginId"));
            #pragma warning disable 8600, 8602, 8604
            Account user = Account.GetAccount(Id);
            if (HttpContext.Session.GetString("LoginId") == null || user.Role.Name != "Admin") {
                return RedirectToPage("/Error", "Show", new { message = "You don't have permission to access this page",
                 instruction = "Please contact the staff to grant you the required permission"});
            }
            ImageData = user.Avatar.ToImg();
            #pragma warning restore 8600, 8602, 8604
            render = a;
            return Page();
        }
        public void OnPostFet(string a) {
            render = a;
        }
        public IActionResult OnPostShip(int Id) {
            Order.ShipOrder(Id);
            return RedirectToPage("/Dashboard", "Fet", new { a = "Orders" });
        }
    }
}