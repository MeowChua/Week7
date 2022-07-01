
using front.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using front.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
/*
var connectionString1 = builder.Configuration.GetConnectionString("ContactsApiConnectionString") ?? throw new InvalidOperationException("Connection string 'frontContextConnection' not found.");

builder.Services.AddDbContext<frontContext>(options =>
    options.UseSqlServer(connectionString1));;

builder.Services.AddDefaultIdentity<frontUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<frontContext>();;
var connectionString = builder.Configuration.GetConnectionString("ContactsApiConnectionString") ?? throw new InvalidOperationException("Connection string 'frontContextConnection' not found.");

*/
// Add services to the container.

builder.
    Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString")));
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();;
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
