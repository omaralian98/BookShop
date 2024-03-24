namespace Bookshop.Models {
    public class Order {
        public int OrderID { get; set; }
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a country name")]
        public string? Country { get; set; }
        [Required(ErrorMessage = "Please enter a governorate name")]
        public string? Governorate { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please enter the street name")]
        public string? Street { get; set; }
        public string? Zip { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
    }
}