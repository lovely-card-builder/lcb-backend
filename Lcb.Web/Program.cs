using System.Text;
using FluentValidation;
using Lcb.BLL;
using Lcb.Infrastructure;
using Lcb.Infrastructure.Configs;
using Lcb.Web.Auth;
using Lcb.Web.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Template.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;


var builder = WebApplication.CreateBuilder();


builder.Host
    .UseSerilog(
        (builderContext, config) =>
        {
            config
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Seq("http://seq")
                .ReadFrom.Configuration(builderContext.Configuration)
                .WriteTo.Console();
        }
    );


builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Logging.AddSerilog(dispose: true);


builder.Services.Configure<StaticConfig>(builder.Configuration.GetSection(nameof(StaticConfig)));
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(nameof(JwtConfig)));
builder.Services.AddSingleton<AuthoriserService>();

builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Configure();
});
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.CustomSchemaIds(type => type.FullName.Replace("+", "."));
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "LCB API",
        Description = "LCB API"
    });
    
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

builder.Services.AddDb(builder.Configuration);
builder.Services.AddBLL();


builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
// ---

var app = builder.Build();

await app.Services.MigrateDb();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (!builder.Environment.IsProduction())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "swagger/{documentName}/swagger.json";
        options.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
        {
            new() { Url = $"https://{httpReq.Host.Value}/api" }
        });
    });
    app.UseSwaggerUI();
}

app.UseCors(policyBuilder => 
    policyBuilder.WithOrigins(
            "http://localhost",
            "http://localhost:4200",
            "https://localhost",
            "https://localhost:4200",
            "http://birdegop.ru",
            "https://birdegop.ru")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());


app.UseMiddleware<ExceptionCatcherMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();