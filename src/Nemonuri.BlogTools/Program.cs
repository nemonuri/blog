﻿using System.Reflection;
using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using Nemonuri.BlogTools;
using YamlDotNet.Serialization;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp;

//--- Arrage ---
MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseYamlFrontMatter().Build();
IDeserializer yamlDeserializer;
{
    var context = new YamlStaticContext();
    yamlDeserializer = new StaticDeserializerBuilder(context).Build();
}
ContentCardConfigRawDataComparer contentCardConfigRawDataComparer = new();
DirectoryInfo blogContentDirectory = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, Constants.BlogContent));
LogTheory.Logger.PathResolved(blogContentDirectory);
Dictionary<FileInfo, FileInfo> fileMap = new(new FileInfoEqualityComparer());
//---|

//--- Initialize _site directory ---
DirectoryInfo siteDirectory;
{
    siteDirectory = GetSiteDirectory();
    if (siteDirectory.Exists)
    {
        siteDirectory.Delete(recursive: true);
        LogTheory.Logger.DirectoryDeleted(nameof(siteDirectory), siteDirectory.FullName);
    }

    siteDirectory.Create();
    LogTheory.Logger.DirectoryCreated(nameof(siteDirectory), siteDirectory.FullName);
}
//---|

//--- Create and sort ContentCardConfigRawData collection ---
var contentCardConfigAndMarkdownDocumentPairs = EnumerateMarkdownDocuments(blogContentDirectory, pipeline)
    .Select
    (
        p =>
        (
            ContentCardConfigRawData: GetContentCardConfig(blogContentDirectory, p.IndexMdFile, p.MarkdownDocument, yamlDeserializer),
            IndexMdFile: p.IndexMdFile,
            MarkdownDocument: p.MarkdownDocument
        )
    );

var contentCardConfigs = contentCardConfigAndMarkdownDocumentPairs
    .Select(p => p.ContentCardConfigRawData)
    .OrderDescending(contentCardConfigRawDataComparer);
//---|

//--- Create index.html file ---
{
    FileInfo indexHtmlFile = new FileInfo(Path.Combine(siteDirectory.FullName, "index.html"));
    LogTheory.Logger.PathResolved(indexHtmlFile);

    var v = indexHtmlFile.CreateParentDirectoryIfNeeded();
    if (v is not null) { LogTheory.Logger.DirectoryCreated(v.FullName); }

    File.WriteAllText(indexHtmlFile.FullName, HtmlTheory.CreateIndexHtml(contentCardConfigs));
    LogTheory.Logger.FileCreated(indexHtmlFile.FullName);
}
//---|

//--- Create blog post files and resource directories ---
foreach (var pair in contentCardConfigAndMarkdownDocumentPairs)
{
    if (pair.ContentCardConfigRawData.RelativeHtmlPath is not { } relativeHtmlPath)
    {
        throw new InvalidOperationException($"{nameof(relativeHtmlPath)} is null");
    }
    if (pair.IndexMdFile.Directory is not { } indexMdDirectory)
    {
        throw new InvalidOperationException($"{nameof(indexMdDirectory)} is null");
    }

    //--- Create blog post html document ---
    IDocument blogPostHtmlDocument = HtmlTheory.CreateBlogPostHtmlDocument(pair.MarkdownDocument, pipeline, pair.ContentCardConfigRawData.Title);

    FileInfo blogPostHtmlFile = new FileInfo(Path.Combine(siteDirectory.FullName, relativeHtmlPath));
    LogTheory.Logger.PathResolved(blogPostHtmlFile);

    if (blogPostHtmlFile.Directory is not { } blogPostHtmlDirectory)
    {
        throw new InvalidOperationException($"{nameof(blogPostHtmlDirectory)} is null");
    }
    fileMap.TryAdd(pair.IndexMdFile, blogPostHtmlFile);
    LogTheory.Logger.FileMapped(pair.IndexMdFile, blogPostHtmlFile);
    //---|

    //--- Create resource directory and resources ---
    {
        DirectoryInfo? destResourceDirectory = null;

        foreach (FileInfo sourceResourceFile in indexMdDirectory.EnumerateFiles("*", SearchOption.AllDirectories).Where(file => file.FullName != pair.IndexMdFile.FullName))
        {
            if (destResourceDirectory is null)
            {
                destResourceDirectory = new DirectoryInfo
                (
                    Path.Combine
                    (
                        siteDirectory.FullName,
                        FileExtensionTheory.RemoveExtension(relativeHtmlPath)
                    )
                );
                LogTheory.Logger.PathResolved(destResourceDirectory);

                destResourceDirectory.Create();
                LogTheory.Logger.DirectoryCreated(destResourceDirectory);
            }

            string relativeSourceResourceFilePath = Path.GetRelativePath(indexMdDirectory.FullName, sourceResourceFile.FullName);
            FileInfo destResourceFile = new FileInfo(Path.Combine(destResourceDirectory.FullName, relativeSourceResourceFilePath));
            LogTheory.Logger.PathResolved(destResourceFile.FullName);

            var v = destResourceFile.CreateParentDirectoryIfNeeded();
            if (v is not null) { LogTheory.Logger.DirectoryCreated(v.FullName); }

            sourceResourceFile.CopyTo(destResourceFile.FullName);
            LogTheory.Logger.FileCreated(destResourceFile.FullName);

            fileMap.TryAdd(sourceResourceFile, destResourceFile);
            LogTheory.Logger.FileMapped(sourceResourceFile, destResourceFile);
        }
    }
    //---|

    //--- Rewrite img src ---
    {
        var imgs = blogPostHtmlDocument.DocumentElement.GetElementsByTagName(TagNames.Img).OfType<IHtmlImageElement>();
        foreach (IHtmlImageElement img in imgs)
        {
            string? url = img.GetAttribute(AttributeNames.Src);
            if
            (
                url is null ||
                url.Contains(':')
            )
            {
                continue;
            }

            FileInfo sourceFile = new FileInfo(Path.Combine(indexMdDirectory.FullName, url));
            if (!fileMap.TryGetValue(sourceFile, out var destFile)) { continue; }

            string relativeUrl = Path.GetRelativePath(blogPostHtmlDirectory.FullName, destFile.FullName);
            relativeUrl = DirectorySeperatorTheory.ReplacePathSeperatorsWithUriStyle(relativeUrl);
            img.SetAttribute(AttributeNames.Src, relativeUrl);
        }
    }
    //---|

    //--- Create blog post file ---
    {
        string html = blogPostHtmlDocument.ToHtml(); //HtmlTheory.ToPrettyFormattedHtml(blogPostHtmlDocument);
        var v = blogPostHtmlFile.CreateParentDirectoryIfNeeded();
        if (v is not null) { LogTheory.Logger.DirectoryCreated(v.FullName); }

        File.WriteAllText(blogPostHtmlFile.FullName, html);
        LogTheory.Logger.FileCreated(blogPostHtmlFile.FullName);
    }
    //---|
}
//---|

static DirectoryInfo GetSiteDirectory()
{
    string siteDirectory =
        typeof(Program).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault(a => a.Key == "SiteDirectory")?.Value
        ?? throw new InvalidOperationException("""Cannot fine "SiteDirectory" AssemblyMetadata.""");

    return new DirectoryInfo(siteDirectory);
}

static IEnumerable<(FileInfo IndexMdFile, MarkdownDocument MarkdownDocument)> EnumerateMarkdownDocuments
(
    DirectoryInfo rootDirectory,
    MarkdownPipeline? pipeline
)
{
    foreach (FileInfo file in rootDirectory.EnumerateFiles("index.md", SearchOption.AllDirectories))
    {
        string markDownText = File.ReadAllText(file.FullName);

        MarkdownDocument markdownDocument = Markdown.Parse(markDownText, pipeline);

        yield return (file, markdownDocument);
    }
}

static ContentCardConfigRawData GetContentCardConfig
(
    DirectoryInfo rootDirectory,
    FileInfo indexMdFile,
    MarkdownDocument markdownDocument,
    IDeserializer yamlDeserializer
)
{
    string relativeMarkdownPath = Path.GetRelativePath(relativeTo: rootDirectory.FullName, path: indexMdFile.FullName);

    if (markdownDocument.OfType<YamlFrontMatterBlock>().FirstOrDefault() is not { } yamlBlock)
    {
        return new () { ErrorMessage = $"Cannot find {nameof(YamlFrontMatterBlock)} in {relativeMarkdownPath}" };
    }

    DiaryYamlFrontMatterRawData diaryYfm;
    {
        var yamlString = yamlBlock.Lines.ToString();
        diaryYfm = yamlDeserializer.Deserialize<DiaryYamlFrontMatterRawData>(yamlString);
    }

    //--- Parse directory name ---
    DateTime date = default;
    string? title = null;
    {
        var regex = RegexTheory.GetDiaryNameRegex();
        if (indexMdFile.Directory?.Name is not { } diaryName)
        {
            return new() { ErrorMessage = $"Cannot find parent directory of {relativeMarkdownPath}" };
        }

        var match = regex.Match(diaryName);
        if (!match.Success)
        {
            return new() { ErrorMessage = $"Cannot parse parent directory name of {relativeMarkdownPath}. Invalid format. ({diaryName})" };
        }

        date = DateTime.TryParse(match.Groups["Date"].Value, out var resultDate) ? resultDate : default;
        title = match.Groups["Title"].Value;
    }
    //---|

    //--- Get category ---
    string? category;
    {
        category = CategoryNameTheory.TranslateCategoryName(indexMdFile.Directory?.Parent?.Name);
    }
    //---|

    //--- Get relative html path ---
    string? relativeHtmlPath;
    { 
        relativeHtmlPath = (diaryYfm.Alias is { } diaryYfmAlias) ?
            $"{diaryYfmAlias}.html" :
            null;
    }
    //---|

    return new ContentCardConfigRawData()
    {
        Title = title,
        Date = date,
        Subindex = diaryYfm.Subindex,
        Category = category,
        RelativeHtmlPath = relativeHtmlPath,
        ErrorMessage = null
    };
}