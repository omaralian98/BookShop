var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

builder.Services.AddDbContext<ShopDbContext>(x => {
    x.UseSqlServer(builder.Configuration["ConnectionStrings:BookshopDatabase"]);
});
builder.Services.AddScoped<IRole, RoleRepository>();
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<IAccount, AccountRepository>();
builder.Services.AddScoped<IBook, BookRepository>();
builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<ISettings, SettingsRepository>();
builder.Services.AddScoped<Cart>(x => SessionCart.GetCart(x));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

app.MapDefaultControllerRoute();

app.MapRazorPages();
SeedRole.EnsurePopulated(app);
SeedCategory.EnsurePopulated(app, app.Environment);
SeedAccount.EnsurePopulated(app, app.Environment);
SeedBook.EnsurePopulated(app, app.Environment);


app.Run();
