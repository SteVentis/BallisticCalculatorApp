using Modules.BallisticCalculations.Core.Abstractions;
using Modules.BallisticCalculations.Core.config;
using Modules.BallisticCalculations.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBallisticCalculationsService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapPost("/ballistic-card/generate", (IBallisticCardService ballisticCardService, InputBallisticData inputBallisticData) =>
{
    return ballisticCardService.GenerateBallisticCard(inputBallisticData);
})
.WithOpenApi();

app.Run();
