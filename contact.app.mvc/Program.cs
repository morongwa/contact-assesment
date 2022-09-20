using contact.app.business.context;
using contact.app.business.entity;
using contact.app.business.repository;
using contact.app.business.tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


builder.Host.ConfigureLogging(bb => bb.AddLog4Net("log4net.config"));

builder.Services.AddDbContext<WebCoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IGenericRepository<OnlineUser>, RepositoryOnlineUser>();
builder.Services.AddScoped<IGenericRepository<Contact>, RepositoryContact>();

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();
builder.Services.AddSession(o =>
{
    o.Cookie.Name = ".contactapp.session";
    o.IdleTimeout = TimeSpan.FromHours(1);
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = SeedStartData.GetContext(services);

    //context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    SeedStartData.OnlineUserData(SeedStartData.GetContext(services));
    SeedStartData.AddressCountryData(SeedStartData.GetContext(services));
    SeedStartData.AddressProvinceData(SeedStartData.GetContext(services));
    SeedStartData.StatusContactData(SeedStartData.GetContext(services));
    SeedStartData.NamedGroupData(SeedStartData.GetContext(services));
    //learn.webcore.mvc.Models.SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
/*
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Assets")),
    RequestPath = "/assets"
});*/

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Start}/{action=Index}/{id?}");

app.Run();

