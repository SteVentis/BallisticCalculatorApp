using Modules.BallisticCalculations.Core.config;
using Modules.WebApp.Endpoints.Input;
using Modules.WebApp.Endpoints.Output;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBallisticCalculationsService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// EndPoints
app.AddBallisticCalculationsInputEndpoints();
app.AddBallisticCalculationsOutputEndpoints();

app.Run();
 