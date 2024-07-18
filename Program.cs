using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlyShare;
using OnlyShare.Database.Repositories;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:44480");
        });
});*/

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSession();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
var jwtSecret = appSettingsSection.Get<AppSettings>().JwtSecret;
builder.Services.Configure<AppSettings>(appSettingsSection);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var dataContext = context.HttpContext.RequestServices.GetRequiredService<DataContext>();
                var userId = context.Principal.Identity.Name;
                var user = dataContext.Users.FirstOrDefault(user => user.Email == userId);

                if (user == null)
                    context.Fail("Unauthorized");

                return Task.CompletedTask;
            }
        };
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else {
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();

if (dataContext == null)
    throw new NullReferenceException("DataContext is not initialized in DI in Program.cs");

dataContext.Database.Migrate();

//Cors policy - zmìna pouze pro specifické stránky
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
