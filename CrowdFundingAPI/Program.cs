using BLL.Interface;
using BLL.Services;
using DAL.Interface;
using DAL.Repositories;
using DemoAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IProjectContributorRepo, ProjectContributorRepo>();
builder.Services.AddScoped<IProjectContributorService, ProjectContributorService>();

builder.Services.AddScoped<IUserService, UserRepo>();
builder.Services.AddScoped<IUserRoleService, UserRoleRepo>();

builder.Services.AddScoped<IStepRepo, StepRepo>();
builder.Services.AddScoped<IStepUserRepo, StepUserRepo>();

builder.Services.AddScoped<ILocalUserService, LocalUserService>();

builder.Services.AddScoped<TokenManager>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("TokenInfo").GetSection("secret").Value))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Auth", policy => policy.RequireAuthenticatedUser());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
