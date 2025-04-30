using InternPortal.API.Hubs;
using InternPortal.Application.Abstractions.Services;
using InternPortal.Application.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Infrastructure.Data;
using InternPortal.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:7100", "https://localhost:44351")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddDbContext<InternPortalDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("InternPortal")));

builder.Services.AddScoped<IInternService, InternService>();
builder.Services.AddScoped<IInternshipService, InternshipService>();
builder.Services.AddScoped<IProjectSevice, ProjectService>();
builder.Services.AddScoped<IInternRepository, InternRepository>();
builder.Services.AddScoped<IInternshipRepository, InternshipRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<InternHub>("/internhub");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<InternPortalDbContext>();
    if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();
}

app.Run();
