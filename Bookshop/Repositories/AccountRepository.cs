namespace Bookshop.Repositories {
    public class AccountRepository : IAccount {
        private ShopDbContext context;
        public AccountRepository(ShopDbContext cont) {
            context = cont;
        }
        public IQueryable<Account> Accounts => context.Accounts.Include(x => x.Role);
        public bool AddAccount(Account account) {
            context.Accounts.Add(account);
            context.SaveChanges();
            return true;
        }
        public void RemoveAccount(long Id) {
            context.Accounts.Remove(context.Accounts.First(x => x.Id == Id));
            context.SaveChanges();
        }
        public bool UpdateAccount(Account account) {
            context.Accounts.Add(account);
            context.SaveChangesWithIdentityInsert<Account>();
            return true;
        }
        public bool FindAccount(long Id) {
            return Accounts.Select(x => x.Id == Id).Count() > 0;
        }
        public bool Login(string username, string password) {
            return Accounts.Where(x => x.Username == username && x.Password == password).Any();
        }
        public Account? GetAccount(long Id) {
            return Accounts.FirstOrDefault(x => x.Id == Id);
        }
        public bool Exists(Account user) {
            if (Accounts.Any(x => x.Username == user.Username)) return true;
            if (Accounts.Any(x => x.Email == user.Email)) return true;
            return false;
        }
    }
}