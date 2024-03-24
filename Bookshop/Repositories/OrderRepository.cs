namespace Bookshop.Models {
    public class OrderRepository : IOrder {
        private ShopDbContext context;
        public OrderRepository(ShopDbContext ctx) {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);
        public void SaveOrder(Order order) {
            context.AttachRange(order.Lines.Select(x => x.Book));
            if (order.OrderID == 0) {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
        public bool ShipOrder(int Id)
        {
            Order? o = Orders.FirstOrDefault(o => o.OrderID == Id);
            if (o != null) {
                o.Shipped = true;
                context.Orders.Update(o);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public Order? GetOrder(int Id) {
            return Orders.FirstOrDefault(x => x.OrderID == Id);
        }
    }
}