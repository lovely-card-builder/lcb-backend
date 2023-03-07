using Lcb.BLL;
using Lcb.Web.Middlewares;
using Template.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder();

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
        Title = "Template API",
        Description = "Template API"
    });
});

builder.Services.AddDb(builder.Configuration);
builder.Services.AddBLL();
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