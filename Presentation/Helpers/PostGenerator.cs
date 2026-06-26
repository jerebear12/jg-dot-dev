using Markdig;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Builder;

namespace Presentation.Helpers;

/// <summary>
/// Generates HTML posts from Markdown files. 
/// </summary>
public static class PostGenerator
{

    public static IApplicationBuilder UsePostGenerator(this IApplicationBuilder builder, DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory)
    {
        static string GetHtmlFileName(DirectoryInfo directory, FileInfo file)
        {
            return directory.FullName + '/' + file.Name.Split('.').First() + ".html";
        }
        
        ArgumentNullException.ThrowIfNull(builder);

        foreach (var file in sourceDirectory.GetFiles())
        {
            if (file.Extension != ".md") continue;

            TryParseFileContentsToHtml(file.FullName)
                .Tap(x => File.WriteAllText(GetHtmlFileName(destinationDirectory, file), x))
                .TapError(x => Console.WriteLine(x));
        }

        return builder;
    }

    private static Result<string> TryParseFileContentsToHtml(string filePath)
    {
        if (!File.Exists(filePath)) return Result.Failure<string>($"File: {filePath} does not exist. Skipping parsing contents to HTML.");

        try
        {
            var fileContents = File.ReadAllText(filePath);
            return Markdown.ToHtml(fileContents);
        }
        catch (Exception e)
        {
            return Result.Failure<string>($"Exception: {e.GetType()} Message: {e.Message}");
        }
    }
    
}