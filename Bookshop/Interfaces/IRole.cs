namespace Bookshop.Interfaces {
    public interface IRole {
        public IQueryable<Role> Roles { get; }
        public bool AddRole(string role);
        public void RemoveRole(int Id);
        public void RemoveRole(string name);
        public bool UpdateRole(Role role);
        public bool FindRole(int Id);
        public Role? GetRole(int Id);
        public int GetRole(string name);
        public bool Exists(string role);
    }
}