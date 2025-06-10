using System.Reflection;
using Markdig;
using Nemonuri.BlogTools;

MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

DirectoryInfo docDirectory = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "doc"));
DirectoryInfo siteDirectory = GetSiteDirectory();
if (siteDirectory.Exists) { siteDirectory.Delete(recursive: true); }

siteDirectory.Create();

//--- Create index.html ---
FileInfo indexHtmlFile = new FileInfo(Path.Combine(siteDirectory.FullName, "index.html"));
indexHtmlFile.GetParentDirectoryIfNotExists()?.Create();
File.WriteAllText(indexHtmlFile.FullName, HtmlTheory.CreateIndexHtml());
//---|

return;

foreach (FileInfo file in docDirectory.EnumerateFiles("*.md", SearchOption.AllDirectories))
{
    string markDownText = File.ReadAllText(file.FullName);

    //Path.re

    var result = Markdown.ToHtml(markDownText, pipeline);

    //Markdown.Parse()
    //Console.WriteLine(filePath);
    Console.WriteLine(result);
}


static DirectoryInfo GetSiteDirectory()
{
    string siteDirectory =
        typeof(Program).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault(a => a.Key == "SiteDirectory")?.Value
        ?? throw new InvalidOperationException("""Cannot fine "SiteDirectory" AssemblyMetadata.""");

    return new DirectoryInfo(siteDirectory);
}