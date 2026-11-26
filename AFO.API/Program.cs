using AFO.Application.Features.ServiceContents.Commands.CreateServiceContent;
using AFO.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile(
        "appsettings.Local.json",
        optional: true,
        reloadOnChange: true
    );

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateServiceContentCommand).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();     // génère le document JSON de l'API
    app.UseSwaggerUI();   // affiche la page web
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
