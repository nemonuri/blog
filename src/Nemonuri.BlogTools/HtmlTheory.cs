using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html;
using AngleSharp.Html.Dom;
using Markdig;
using Markdig.Helpers;
using Markdig.Syntax;

namespace Nemonuri.BlogTools;

public static class HtmlTheory
{
    public static string CreateIndexHtml(IEnumerable<ContentCardConfigRawData>? contentCardConfigs = null)
    {
        IDocument document = CreateBasicHtmlDocument();
        document.SetRootLanguageAsKorean();

        document.Title = "네모누리의 블로그";

        //--- h1 라벨 추가 ---
        {
            if (document.CreateElement(TagNames.H1) is IHtmlHeadingElement h1)
            {
                h1.TextContent = "네모누리의 블로그";
                document.Body?.AppendChild(h1);
            }
        }
        //---|

        //--- 콘텐츠 카드 추가 ---
        {
            foreach (var contentCardConfig in contentCardConfigs ?? [])
            {
                var contentCard = document.CreateDiv();
                {
                    var title = document.CreateDiv();
                    {
                        var a = document.CreateA();
                        a.Href = contentCardConfig.RelativeHtmlPath ?? "";
                        a.TextContent = contentCardConfig.Title ?? "(No Title)";

                        title.AppendChild(a);
                    }

                    contentCard.AppendChild(title);
                }
                {
                    var categoty = document.CreateDiv();
                    categoty.TextContent = contentCardConfig.Category ?? "(No Category)";

                    contentCard.AppendChild(categoty);
                }
                {
                    var date = document.CreateDiv();
                    date.TextContent = contentCardConfig.Date != default ? contentCardConfig.Date.ToString("yyyy-MM-dd") : "(No Date)";

                    contentCard.AppendChild(date);
                }
                {
                    if (!string.IsNullOrEmpty(contentCardConfig.ErrorMessage))
                    {
                        var error = document.CreateDiv();
                        error.TextContent = contentCardConfig.ErrorMessage;

                        contentCard.AppendChild(error);
                    }
                }

                document.Body?.AppendChild(contentCard);
            }
        }
        //---|

        string result = document.ToPrettyFormattedHtml();

        return result;
    }

    public static IDocument CreateBlogPostHtmlDocument
    (
        MarkdownDocument markdownDocument,
        MarkdownPipeline? pipeline,
        string? subTitle
    )
    {
        IDocument document = CreateBasicHtmlDocument();
        document.SetRootLanguageAsKorean();

        document.Title = string.Concat("네모누리의 블로그", " - ", subTitle ?? "No Title");

        string mdToHtml = markdownDocument.ToHtml(pipeline);
        LogTheory.Logger.MarkdownConvertedToHtml(mdToHtml);

        if (document.Body is { } body)
        {
            body.InnerHtml = mdToHtml;
        }

        //--- 코드 블록 렌더링 수정 ---
        foreach (var codeElement in document.Body?.Descendants<IHtmlElement>()?.Where(e => string.Equals(e.TagName, TagNames.Code, StringComparison.InvariantCultureIgnoreCase)) ?? [])
        {
            if
            (
                codeElement.ClassList
                    .Select(className => RegexTheory.GetLanguageNameRegex().Match(className))
                    .FirstOrDefault(m => m.Success) is not { } match
            )
            {
                continue;
            }

            string languageName = match.Groups["LanguageName"].Value;
            if (string.IsNullOrEmpty(languageName))
            {
                continue;
            }

            var syntaxed = JavascriptTheory.HighlightSyntax(codeElement.InnerHtml, languageName, out bool languageExists);
            if (!languageExists) { continue; }

            codeElement.InnerHtml = syntaxed;
        }
        //---|

        return document;
    }

    private static IDocument? _basicHtmlDocument;
    public static IDocument CreateBasicHtmlDocument()
    {
        if (_basicHtmlDocument is null)
        {
            IBrowsingContext context = BrowsingContext.New();
            string basicHtmlText = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "html-template", "basic.html"));
            _basicHtmlDocument = context.OpenAsync(req => req.Content(basicHtmlText)).Result;
        }
        return (IDocument)_basicHtmlDocument.Clone(deep: true);
    }

    public static IHtmlMetaElement CreateMetaElementAndAppendToHead(this IDocument document)
    {
        IHtmlMetaElement metaElement = document.CreateMetaElement();
        document.Head?.AppendChild(metaElement);
        return metaElement;
    }

    public static IHtmlMetaElement CreateMetaElement(this IDocument document)
    {
        return document.CreateElement(TagNames.Meta) is IHtmlMetaElement metaElement
            ? metaElement
            : throw new InvalidOperationException($"Cannot get {nameof(IHtmlMetaElement)}");
    }

    public static void SetRootLanguageAsKorean(this IDocument document) => document.SetRootLanguage("ko-kr");

    public static void SetRootLanguage(this IDocument document, string languageTag)
    {
        if (document.DocumentElement is IHtmlHtmlElement htmlElement)
        {
            htmlElement.SetAttribute(null, AttributeNames.Lang, languageTag);
        }
    }

    private static IMarkupFormatter? _prettyFormatter;
    public static string ToPrettyFormattedHtml(this IDocument document)
    {
        return document.ToHtml(_prettyFormatter ??= new PrettyMarkupFormatter());
    }

    public static IHtmlDivElement CreateDiv(this IDocument document) => (IHtmlDivElement)document.CreateElement(TagNames.Div);
    public static IHtmlAnchorElement CreateA(this IDocument document) => (IHtmlAnchorElement)document.CreateElement(TagNames.A);

}
