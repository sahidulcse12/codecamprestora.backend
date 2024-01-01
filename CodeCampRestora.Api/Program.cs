using CodeCampRestora.Application;
using CodeCampRestora.Api.Settings;
using CodeCampRestora.Infrastructure;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi()
    .AddSwagger()
    .AddApplicationServices()
    .AddInfrastructureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.MapControllers();

app.Run();
