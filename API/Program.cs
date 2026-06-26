using Microsoft.AspNetCore.Rewrite;
using Presentation;
using Presentation.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UsePostGenerator(
    new DirectoryInfo(blogPostSourceDirectory),
    new DirectoryInfo(blogPostDestinationDirectory));

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

var rewriteOptions = new RewriteOptions()
    .AddRewrite(@"^blog/(.+)$", "blog/post?slug=$1", skipRemainingRules: true);
app.UseRewriter(rewriteOptions);

app.Run();
