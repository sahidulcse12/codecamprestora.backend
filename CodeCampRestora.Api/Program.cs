using CodeCampRestora.Api.Settings;
using CodeCampRestora.Infrastructure;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Infrastructure.Data.Repositories;
using CodeCampRestora.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Infrastructure.Data.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi()
    .AddSwagger();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("BlogBbContext"),
        b => b.MigrationsAssembly("CodeCampRestora.Api"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IBlogService), typeof(BlogService));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
