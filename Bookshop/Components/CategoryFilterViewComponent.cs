namespace Bookshop.Components {
    public class CategoryFilterViewComponent : ViewComponent {
        private ICategory category;
        public CategoryFilterViewComponent(ICategory cate) {
            category = cate;
        }
        public IViewComponentResult Invoke() {
            return View(category.Categories);
        }
    }
}