namespace Bookshop.Interfaces {
    public interface IAccount {
        public IQueryable<Account> Accounts { get; }
        public bool AddAccount(Account account);
        public void RemoveAccount(long Id);
        public bool UpdateAccount(Account account);
        public bool FindAccount(long Id);
        public bool Login(string username, string password);
        public Account? GetAccount(long Id);
        public bool Exists(Account user);
    }
}