using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Modules.BallisticCalculations.Core.config;
using Modules.BallisticCalculations.Endpoints;
using Modules.Security.Domain.Models;
using Modules.Security.Endpoints;
using Modules.Security.Infrastructure.config;
using Modules.Security.Infrastructure.Context;
using Serilog;
using System;
using WebApp.AuthOptionSetup;
using WebApp.EmailOptions;
using WebApp.Middleware;
using Modules.Security.Infrastructure.Authentication.Email;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services
builder.Services.AddBallisticCalculationsModuleServices();
builder.Services.AddSecurityModuleServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
    opt.AddPolicy("SuperUser", policy => policy.RequireRole("SuperUser"));
    opt.AddPolicy("User", policy => policy.RequireRole("User"));
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityAppDbContext>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation");

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));

builder.Services.Configure<EmailConfirmationTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromDays(3));

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = true;
});
var emailConfig = builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>();

// Jwt Settings
builder.Services.ConfigureOptions<JwtSettingsSetup>();
builder.Services.ConfigureOptions<JwtBearerSettingsSetup>();

// Add Serilog
var logger = new LoggerConfiguration()
   .ReadFrom.Configuration(new ConfigurationBuilder()
   .AddJsonFile("serilog.config.json")
   .Build())
   .Enrich.FromLogContext()
   .CreateLogger();


builder.Host.UseSerilog(logger);

// Add Middleware
builder.Services.AddScoped<ExceptionMiddleware>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

// Add EndPoints
app.AddAuthEndpoints();
app.AddAdminEndpoints();
app.AddBallisticCalculationsEndpoints();

app.Run();
