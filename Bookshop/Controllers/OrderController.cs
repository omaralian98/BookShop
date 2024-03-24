namespace Bookshop.Controllers {
    public class OrderController : Controller {
        IOrder repository;
        private Cart cart;
        private IBook book;
        public OrderController(IOrder repoService, Cart cartService, IBook bo) {
            repository = repoService;
            cart = cartService;
            book = bo;
        }
        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order) {
            if (cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid) {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            } 
            else {
                return View();
            }
        }
    }
}