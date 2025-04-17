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
        policy.WithOrigins("https://localhost:44309")
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
