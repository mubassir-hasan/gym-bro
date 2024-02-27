using FluentValidation.AspNetCore;
using GymBro.Api.Services;
using GymBro.Application;
using GymBro.Application.Authentication.Interfaces;
using GymBro.Application.Authentication.Models;
using GymBro.Application.Common.Interfaces;
using GymBro.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

//builder.Services.Scan(selector => selector
//.FromAssemblies(GymBro.Application.AssemblyReference.Assembly,
//GymBro.Infrastructure.AssemblyReference.Assembly)
//.AddClasses(false)
//.AsImplementedInterfaces()
//.WithScopedLifetime()
//);

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(GymBro.Application.AssemblyReference.Assembly);
    cfg.RegisterServicesFromAssembly(GymBro.Domain.AssemblyReference.Assembly);
});
// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.Configure<GoogleAuthConfigModel>(configuration.GetSection("Authentication:Google"));
var jwtSection = builder.Configuration.GetSection("JWT");
builder.Services.Configure<JwtModel>(jwtSection);

var appSettings = jwtSection.Get<JwtModel>();
if (appSettings != null)
{
    var secret = Encoding.ASCII.GetBytes(appSettings.Secret);
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer("Bearer", options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = appSettings.ValidAudience,
            ValidIssuer = appSettings.ValidIssuer,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret)),
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
        };
    });
}



builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers(
            //options =>
            //options.Filters.Add<ApiExceptionFilterAttribute>()
            );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
