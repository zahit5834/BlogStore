using BlogStore.BusinessLayer.Abstract;
using BlogStore.BusinessLayer.Concrete;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Context;
using BlogStore.DataAccessLayer.EntityFramework;
using BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using BlogStore.BusinessLayer.Container;
using BlogStore.BusinessLayer.Services;
using BlogStore.BusinessLayer.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddBusinessServices();


builder.Services.AddDbContext<BlogContext>();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<BlogContext>();

builder.Services.AddControllersWithViews();

builder.Services.Configure<GoogleTranslateOptions>(
    builder.Configuration.GetSection("GoogleTranslate")
);
builder.Services.AddHttpClient<GoogleTranslateService>();

// IConfiguration eriþimi
var configuration = builder.Configuration;

// AppSettings içinden OpenAI key'i oku
var openAiApiKey = configuration["HuggingFace:ApiKey"];
builder.Services.Configure<HuggingSettings>(builder.Configuration.GetSection("HuggingFace"));
builder.Services.AddHttpClient<IToxicityChecker, ToxicityChecker>();
// appsettings.json'daki deðeri konfigürasyon olarak veriyoruz
builder.Services.AddSingleton(new HuggingSettings
{
    ApiKey = openAiApiKey
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
