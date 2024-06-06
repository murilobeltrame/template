using System.IO.Compression;
using System.Reflection;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddResponseCompression(options => {
        options.EnableForHttps = false;
        options.Providers.Add<GzipCompressionProvider>();
        options.Providers.Add<BrotliCompressionProvider>();
    })
    .Configure<GzipCompressionProviderOptions>(configuration => configuration.Level = CompressionLevel.Optimal)
    .Configure<BrotliCompressionProviderOptions>(configuration => configuration.Level = CompressionLevel.Optimal);

builder.Services.AddResponseCaching();

builder.Services
    .AddControllers(options => options.RespectBrowserAcceptHeader = true)
    .AddXmlSerializerFormatters();

builder.Services
    .AddEndpointsApiExplorer()
    .AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.Conventions.Add(new VersionByNamespaceConvention());
        options.AssumeDefaultVersionWhenUnspecified = true;
    })
    .AddVersionedApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
    });
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => {
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var versionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{ versionDescription.GroupName }/swagger.json", versionDescription.GroupName.ToUpperInvariant());
    }
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/healthz");

app.Run();

//versioning
//healthchecks
//xmldocumentation
//internationalisation
//response caching
//exception middleware
//tracing

public partial class Program {}