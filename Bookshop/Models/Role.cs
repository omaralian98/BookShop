namespace Bookshop.Models {
    public class Role {
        public int Id { get; set; }
        public string Name { get; set; } = "New Role";
        public List<Account>? Accounts { get; set; }
    }
}