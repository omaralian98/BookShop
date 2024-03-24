namespace Bookshop.Models {
    public class Account {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public byte[]? Avatar { get; set; }
        public Role? Role { get; set; }
    }
}