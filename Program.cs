using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using ProjetoFloresta.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
//builder.Services.AddAuthentication("Identity.Application")
//        .AddCookie(options =>
//        {
//            options.LoginPath = "/Identity/Account/Login"; // Defina o caminho de login
//        });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Rota padrão para controladores
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Mapeamento das Razor Pages
    endpoints.MapRazorPages();

    // Verifica se o usuário está autenticado antes de redirecionar
    endpoints.MapGet("/", context =>
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            // Redireciona para a página de login se o usuário não estiver autenticado
            context.Response.Redirect("/Identity/Account/Login");
        }
        else
        {
            // Redireciona para a home padrão caso o usuário esteja autenticado
            context.Response.Redirect("/Home/Index");
        }
        return Task.CompletedTask;
    });
});


app.Run();
