var builder = WebApplication.CreateBuilder(args);
//builder.Logging.ClearProviders();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddDebug();
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Die Protokollierung(Logging) kann ohne Abh�ngigkeitsinjektion(Dependency Injection) erfolgen, wie unten beschrieben 
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Die App wird hochgefahren...");

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
