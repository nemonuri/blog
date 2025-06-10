using System.Reflection;
using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using Nemonuri.BlogTools;
using YamlDotNet.Serialization;

//--- Arrage ---
MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseYamlFrontMatter().Build();
IDeserializer yamlDeserializer;
{
    var context = new YamlStaticContext();
    yamlDeserializer = new StaticDeserializerBuilder(context).Build();
}
ContentCardConfigRawDataComparer contentCardConfigRawDataComparer = new();
DirectoryInfo docDirectory = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "doc"));
//---|

//--- Initialize .site directory ---
DirectoryInfo siteDirectory;
{ 
    siteDirectory = GetSiteDirectory();
    if (siteDirectory.Exists) { siteDirectory.Delete(recursive: true); }

    siteDirectory.Create();
}
//---|

//--- Create and sort ContentCardConfigRawData collection ---
var contentCardConfigAndMarkdownDocumentPairs = EnumerateMarkdownDocuments(docDirectory, pipeline)
    .Select(p => (ContentCardConfigRawData: GetContentCardConfig(docDirectory, p.FileInfo, p.MarkdownDocument, yamlDeserializer), MarkdownDocument: p.MarkdownDocument));

var contentCardConfigs = contentCardConfigAndMarkdownDocumentPairs
    .Select(p => p.ContentCardConfigRawData)
    .OrderDescending(contentCardConfigRawDataComparer);
//---|

//--- Create index.html file ---
{ 
    FileInfo indexHtmlFile = new FileInfo(Path.Combine(siteDirectory.FullName, "index.html"));
    indexHtmlFile.GetParentDirectoryIfNotExists()?.Create();
    File.WriteAllText(indexHtmlFile.FullName, HtmlTheory.CreateIndexHtml(contentCardConfigs));
}
//---|

//--- Create blog post files ---
foreach (var pair in contentCardConfigAndMarkdownDocumentPairs)
{
    if (pair.ContentCardConfigRawData.RelativeHtmlPath is not { } relativeHtmlPath)
    {
        throw new InvalidOperationException($"{nameof(relativeHtmlPath)} is null");
    }

    string html = HtmlTheory.CreateBlogPostHtml(pair.MarkdownDocument, pipeline, pair.ContentCardConfigRawData.Title);
    FileInfo blogPostHtmlFile = new FileInfo(Path.Combine(siteDirectory.FullName, relativeHtmlPath));
    blogPostHtmlFile.GetParentDirectoryIfNotExists()?.Create();
    File.WriteAllText(blogPostHtmlFile.FullName, html);
}
//---|

static DirectoryInfo GetSiteDirectory()
{
    string siteDirectory =
        typeof(Program).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault(a => a.Key == "SiteDirectory")?.Value
        ?? throw new InvalidOperationException("""Cannot fine "SiteDirectory" AssemblyMetadata.""");

    return new DirectoryInfo(siteDirectory);
}

static IEnumerable<(FileInfo FileInfo, MarkdownDocument MarkdownDocument)> EnumerateMarkdownDocuments
(
    DirectoryInfo rootDirectory,
    MarkdownPipeline? pipeline
)
{
    foreach (FileInfo file in rootDirectory.EnumerateFiles("*.md", SearchOption.AllDirectories))
    {
        string markDownText = File.ReadAllText(file.FullName);

        MarkdownDocument markdownDocument = Markdown.Parse(markDownText, pipeline);

        yield return (file, markdownDocument);
    }
}

static ContentCardConfigRawData GetContentCardConfig
(
    DirectoryInfo rootDirectory,
    FileInfo markdownFile,
    MarkdownDocument markdownDocument,
    IDeserializer yamlDeserializer
)
{
    string relativeMarkdownPath = Path.GetRelativePath(relativeTo: rootDirectory.FullName, path: markdownFile.FullName);

    if (markdownDocument.OfType<YamlFrontMatterBlock>().FirstOrDefault() is not { } yamlBlock)
    {
        return new ContentCardConfigRawData() { ErrorMessage = $"Cannot find {nameof(YamlFrontMatterBlock)} in {relativeMarkdownPath}" };
    }

    YamlFrontMatterRawData yfm;
    {
        var yamlString = yamlBlock.Lines.ToString();
        yfm = yamlDeserializer.Deserialize<YamlFrontMatterRawData>(yamlString);
    }

    var relativeHtmlPath = FileExtensionTheory.ChangeExtension(relativeMarkdownPath, ".html");

    return new ContentCardConfigRawData()
    {
        Title = yfm.Title,
        Date = yfm.Date,
        DailyIndex = yfm.DailyIndex,
        Category = markdownFile.Directory?.Name,
        RelativeHtmlPath = relativeHtmlPath,
        ErrorMessage = null
    };
}
