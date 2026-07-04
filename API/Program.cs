using API.Helpers;
using Asp.Versioning;
using Microsoft.AspNetCore.Rewrite;
using Presentation;
using Presentation.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation();
builder.Services.AddControllers();

builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1.0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VV";
        options.SubstituteApiVersionInUrl = true;
        options.SubstitutionFormat = "VV";
        options.AssumeDefaultVersionWhenUnspecified = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureOptions<SwaggerGenConfiguration>();
builder.Services.AddSwaggerGen();

var blogPostSourceDirectory = builder.Configuration.GetValue<string>("PostsSourceDirectory");
ArgumentNullException.ThrowIfNull(blogPostSourceDirectory);

var blogPostDestinationDirectory = builder.Configuration.GetValue<string>("PostsDestinationDirectory");
ArgumentNullException.ThrowIfNull(blogPostDestinationDirectory);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UsePostGenerator(
    new DirectoryInfo(blogPostSourceDirectory),
    new DirectoryInfo(blogPostDestinationDirectory));

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

var rewriteOptions = new RewriteOptions()
    .AddRewrite(@"^blog/(.+)$", "blog/post?slug=$1", skipRemainingRules: true);
app.UseRewriter(rewriteOptions);

app.Run();
