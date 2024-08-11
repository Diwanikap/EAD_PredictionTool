

using EAD_PredictionTool.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString
    ("Prediction_tool"))
    );
builder.Services.AddDbContext<StudySession_Context>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString
    ("Prediction_tool"))
    );
builder.Services.AddDbContext<Break_Context>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString
    ("Prediction_tool"))
    );

builder.Services.AddHttpClient();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
        name: "Prediction",
        pattern: "{controller=Prediction}/{action=Index}/{id?}");
app.MapControllerRoute(
        name: "Login",
        pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
