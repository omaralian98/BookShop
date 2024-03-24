using System.Net.Mime;
namespace Bookshop.Models {
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; } = "New Category";
        public byte[]? Image { get; set; }
        public List<Book>? Books { get; set; }
    }
}