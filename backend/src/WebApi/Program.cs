using Application;
using Infrastructure;
using NSwag;

var builder = WebApplication.CreateBuilder(args);

var generationBuild = args.Length >= 1;
if (generationBuild && args[0].Contains("appsettings.json"))
{
    builder.Configuration.AddJsonFile(args[0], optional: false);
}

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddOpenApiDocument(settings =>
{
    settings.Title = "StudyHub";
    settings.DocumentName = "v1";

    settings.PostProcess = document =>
    {
        document.Schemes = new[] { OpenApiSchema.Https, OpenApiSchema.Http };
    };
});

var app = builder.Build();

app.UseOpenApi(settings =>
{
    settings.Path = "/api/swagger/{documentName}/swagger.json";
    settings.PostProcess = (document, request) =>
    {
        document.Schemes = new[] { OpenApiSchema.Https, OpenApiSchema.Http };
    };
});

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api/swagger";
    settings.DocumentPath = "/api/swagger/{documentName}/swagger.json";
    settings.DocExpansion = "list";
});

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
