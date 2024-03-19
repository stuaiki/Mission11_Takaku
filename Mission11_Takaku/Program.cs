using Microsoft.EntityFrameworkCore;
using Mission11_Takaku.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//connect with database
builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookstoreConnection"]);
});

//connect with Interface and EF
builder.Services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// created new default mapping
app.MapControllerRoute("pagination", "Books/{pageNum}", new {Controller = "Home", action = "Index"});
app.MapDefaultControllerRoute();

app.Run();
