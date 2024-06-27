using BookingTourAPI.DependencyInjection;
using DataAccess;
using DataAccess.Entites;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static BusinessLogic.Configuration.ConfigurationModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
option.SwaggerDoc("v1", new OpenApiInfo { Title = "TourBooking API", Version = "v1" });
option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    In = ParameterLocation.Header,
    Description = "Please enter a valid token",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    Scheme = "Bearer"
});
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtSettings:Key").Value ??
    throw new Exception("JwtSettings:Key is not found"));
var tokenValidationParameter = new TokenValidationParameters()
{

    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,

    IssuerSigningKey = new SymmetricSecurityKey(key),
    RequireExpirationTime = true,
    ClockSkew = TimeSpan.Zero
};


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
           .AddJwtBearer(jwt =>
           {
               jwt.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = async (context) =>
                   {
                       //context.Response.StatusCode = 401; //UnAuthorized
                       //await context.Response.WriteAsync("Invalid User Key");
                       throw new UnauthorizedAccessException("Failed to vailidate token");
                   }
               };
               jwt.SaveToken = true;
               jwt.TokenValidationParameters = tokenValidationParameter;
           });
builder.Services.InitializerDependencyInjection(builder.Configuration);
builder.Services.AddSingleton(tokenValidationParameter);
var firebaseConfigSection =builder.Configuration.GetSection("Firebase");
var firebaseConfig = firebaseConfigSection.Get<FirebaseConfiguration>();
builder.Services.Configure<FirebaseConfiguration>(firebaseConfigSection);
builder.Services.AddSingleton(firebaseConfig);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
