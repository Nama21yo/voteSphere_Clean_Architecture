using Microsoft.EntityFrameworkCore;
using voteSphere.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Load the appsettings.json from the Presentation layer if it is not present in Infrastructure
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json"); // Make sure appsettings.json is in the Presentation layer

// Configure PostgreSQL Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VotingContext>(options =>
    options.UseNpgsql(connectionString)); // Use PostgreSQL

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
