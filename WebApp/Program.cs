using Microsoft.AspNetCore.Authentication.JwtBearer;
using Modules.BallisticCalculations.Core.config;
using Modules.BallisticCalculations.Endpoints;
using Modules.Security.Endpoints;
using Modules.Security.Infrastructure.config;
using WebApp.AuthOptionSetup;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add Services
builder.Services.AddBallisticCalculationsModuleServices();
builder.Services.AddSecurityModuleServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization( opt =>
{
    opt.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
    opt.AddPolicy("SuperUser", policy => policy.RequireRole("SuperUser"));
    opt.AddPolicy("User", policy => policy.RequireRole("User"));
});

builder.Services.ConfigureOptions<JwtSettingsSetup>();
builder.Services.ConfigureOptions<JwtBearerSettingsSetup>();


var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add EndPoints
app.AddAuthEndpoints();
app.AddAdminEndpoints();
app.AddBallisticCalculationsEndpoints();

app.Run();
 