using ReactWithASP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Database Context Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Controllers and Views
builder.Services.AddControllersWithViews();

// Enable Application Insights for logging
builder.Services.AddApplicationInsightsTelemetry();

// CORS Policy (Ensures Frontend Access)
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:44485")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register Email Service
builder.Services.AddSingleton<EmailService>();

// Authentication Configuration (Cookie-based authentication)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Ensure this matches the React login page route
    });

// Swagger Configuration (API Documentation for Development)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the App
var app = builder.Build();

// Middleware Configuration AFTER app.Build()
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Enable CORS for frontend communication
app.UseCors(MyAllowSpecificOrigins);

// Add Authentication Middleware
app.UseAuthentication();
app.UseAuthorization();

// Define Default Route for Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Serve React App (Ensure this line is here for frontend routing)
app.MapFallbackToFile("index.html");

// Start the app
app.Run();
