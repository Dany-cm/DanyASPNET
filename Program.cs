using DanyTCG.Data;
using DanyTCG.Schemas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TcgContext>(options =>
    options.UseSqlite("Data Source=DanyTCG.db"));

// Register schemas
builder
    .Services
    .AddScoped<CardSchema>()
    .AddScoped<EditionSchema>()
    .AddScoped<RaritySchema>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();