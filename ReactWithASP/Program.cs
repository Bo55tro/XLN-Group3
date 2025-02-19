using ReactWithASP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Add Services BEFORE app.Build()

// Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=Database/XLN-Database.db"));

// CORS Policy
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

// Controllers, Swagger, and Endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ 2. Add Authentication BEFORE calling builder.Build()
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Adjust as needed.
    });

// ✅ 3. Build the App
var app = builder.Build();

// ✅ 4. Middleware Configuration AFTER app.Build()
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Add Authentication Middleware
app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

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
app.Run();
