namespace Bookshop.Pages {
    public class ErrorModel : PageModel {
        public string Message { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;
        public void OnGetShow(string message, string instruction = "") {
            Message = message;
            Instruction = instruction;
        }
    }
}