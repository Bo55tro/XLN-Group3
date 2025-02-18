<<<<<<< Updated upstream
using ReactWithASP.Data;
using Microsoft.EntityFrameworkCore;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Add Services BEFORE app.Build()
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=Database/XLN-Database.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://localhost:44485")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// ✅ 2. Add Controllers BEFORE app.Build()
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ 3. Now Build the App
var app = builder.Build();

// ✅ 4. Middleware Configuration (AFTER app.Build())
app.UseCors(MyAllowSpecificOrigins);
=======
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configure Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Controllers and Views
builder.Services.AddControllersWithViews();

// Enable Application Insights for logging
builder.Services.AddApplicationInsightsTelemetry();

// Configure CORS to allow frontend access
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSingleton<EmailService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); 
}

>>>>>>> Stashed changes
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

<<<<<<< Updated upstream
// ✅ 5. Enable Swagger Only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

// ✅ 6. Start the App
=======
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAllOrigins"); 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Serve React app (Ensure this line is here!)
app.MapFallbackToFile("index.html");

>>>>>>> Stashed changes
app.Run();



