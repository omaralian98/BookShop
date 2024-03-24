namespace Bookshop.Interfaces {
    public interface ISettings {
        public IQueryable<Settings> Settings { get; }
        public void UpdateSettings(int BookPerPage);
        public int GetBookPerPage();
    }
}