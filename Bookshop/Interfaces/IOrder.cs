namespace Bookshop.Models {
    public interface IOrder {
        public IQueryable<Order> Orders { get; }
        public void SaveOrder(Order order);
        public bool ShipOrder(int Id);
        public Order? GetOrder(int Id);
    }
}