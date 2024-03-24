namespace Bookshop.Repositories {
    public class SettingsRepository : ISettings {
        private ShopDbContext context;
        public SettingsRepository(ShopDbContext cont) {
            context = cont;
        }
        public IQueryable<Settings> Settings => context.Settings;
        public void UpdateSettings(int BookPerPage) {
            Settings fir = Settings.First();
            fir.BookPerPage = BookPerPage;
            context.Settings.Update(fir);
            context.SaveChanges();
        }
        public int GetBookPerPage() {
            return context.Settings.First(x => x.Id == 1).BookPerPage;
        }
    }
}