using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
    {
        Description = "Development Server",
        Url = "https://localhost:7274"
    });
});

var url = Environment.GetEnvironmentVariable("DatabaseUrl");
var key = Environment.GetEnvironmentVariable("DatabaseKey");
var options = new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true,
};

builder.Services.AddSingleton(provider => new Supabase.Client(url!, key, options));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();