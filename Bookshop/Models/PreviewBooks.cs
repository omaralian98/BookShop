namespace Bookshop.Models {
    public class PreviewBooks {
        public List<Book>? books { get; set; }
        public int PreviousPage { get; set; }
        public int CurrentPage { get; set; }
        public int NextPage { get; set; }
        public int TotalPages { get; set;}
    }
}