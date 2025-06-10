using System.Reflection;
using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using Nemonuri.BlogTools;
using YamlDotNet;
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
var contentCardConfigs = EnumerateMarkdownDocuments(docDirectory, pipeline)
    .Select(p => GetContentCardConfig(docDirectory, p.FileInfo, p.MarkdownDocument, yamlDeserializer))
    .OrderDescending(contentCardConfigRawDataComparer);
//---|

//--- Create index.html ---
{ 
    FileInfo indexHtmlFile = new FileInfo(Path.Combine(siteDirectory.FullName, "index.html"));
    indexHtmlFile.GetParentDirectoryIfNotExists()?.Create();
    File.WriteAllText(indexHtmlFile.FullName, HtmlTheory.CreateIndexHtml(contentCardConfigs));
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
    string relativePath = Path.GetRelativePath(relativeTo: rootDirectory.FullName, path: markdownFile.FullName);

    if (markdownDocument.OfType<YamlFrontMatterBlock>().FirstOrDefault() is not { } yamlBlock)
    {
        return new ContentCardConfigRawData() { ErrorMessage = $"Cannot find {nameof(YamlFrontMatterBlock)} in {relativePath}" };
    }

    YamlFrontMatterRawData yfm;
    {
        var yamlString = yamlBlock.Lines.ToString();
        yfm = yamlDeserializer.Deserialize<YamlFrontMatterRawData>(yamlString);
    }

    return new ContentCardConfigRawData()
    {
        Title = yfm.Title,
        Date = yfm.Date,
        DailyIndex = yfm.DailyIndex,
        Category = markdownFile.Directory?.Name,
        RelativePath = relativePath,
        ErrorMessage = null
    };
}