namespace Bookshop.Models {
    public class Book {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = "Anonymous";
        public byte[]? Coverpage { get; set; }
        public byte[]? PDF { get; set; }
        [JsonIgnore]
        public List<Category>? Categories { get; set; }
        public DateTime PublishDate { get; set; }
        public int Pages { get; set; }
        [Column(TypeName = "decimal(8, 1)")]
        public decimal Rating { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; } = "There is no Description for this Book yet";
    }
}