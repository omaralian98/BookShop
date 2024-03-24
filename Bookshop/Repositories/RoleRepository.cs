namespace Bookshop.Repositories {
    public class RoleRepository : IRole {
        private ShopDbContext context;
        public RoleRepository(ShopDbContext cont) {
            context = cont;
        }
        public IQueryable<Role> Roles => context.Roles.Include(x => x.Accounts);
        public bool AddRole(string role) {
            context.Roles.Add(new Role{
                Name = role
            });
            context.SaveChanges();
            return true;
        }
        public void RemoveRole(int Id) {
            context.Roles.Remove(context.Roles.First(x => x.Id == Id));
            context.SaveChanges();
        }
        public void RemoveRole(string name) {
            RemoveRole(GetRole(name));
        }
        public bool UpdateRole(Role Role) {
            context.Roles.Add(Role);
            context.SaveChangesWithIdentityInsert<Role>();
            return true;
        }
        public bool FindRole(int Id) {
            return Roles.Select(x => x.Id == Id).Count() > 0;
        }
        public Role? GetRole(int Id) {
            return Roles.FirstOrDefault(x => x.Id == Id);
        }
        public int GetRole(string name) {
            #pragma warning disable 8602
            return Roles.FirstOrDefault(x => x.Name == name).Id;
            #pragma warning restore 8602
        }
        public bool Exists(string role) {
            if (Roles.Any(x => x.Name == role)) return true;
            return false;
        }
    }
}