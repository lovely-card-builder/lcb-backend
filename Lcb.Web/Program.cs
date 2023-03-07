using Espa.BLL.Validator;
using FluentValidation;
using Lcb.BLL;
using Lcb.BLL.Validator;
using Lcb.Web.Middlewares;
using MediatR;
using Template.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
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


builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Configure();
});
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "LCB API",
        Description = "LCB API"
    });
});

builder.Services.AddDb(builder.Configuration);
builder.Services.AddBLL();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
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

app.MapControllers();

app.Run();