using DynamicForms.Infrastructure.SeedData;
using DynamicForms.Presentation.Setup;
using FastEndpoints;
using FastEndpoints.Swagger;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatorSetup();
builder.AddCompanyMongoRepository();

builder.Services.AddSwaggerSetup();

var app = builder.Build();
app.UseFastEndpoints()
    .UseSwaggerGen();


using (var scope = app.Services.CreateScope())
{
    var seedData = scope.ServiceProvider.GetRequiredService<SeedData>();
    await seedData.SeedAsync();
}

app.Run();