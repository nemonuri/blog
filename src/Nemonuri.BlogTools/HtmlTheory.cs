using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html;
using AngleSharp.Html.Dom;

namespace Nemonuri.BlogTools;

public static class HtmlTheory
{
    public static string CreateIndexHtml(IEnumerable<ContentCardConfigRawData>? contentCardConfigs = null)
    {
        IBrowsingContext context = BrowsingContext.New();
        string basicHtmlText = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "html-template", "basic.html"));
        IDocument document = context.OpenAsync(req => req.Content(basicHtmlText)).Result;

        document.Title = "네모누리의 블로그";

        //--- 언어를 한국어로 설정 ---
        {
            if (document.DocumentElement is IHtmlHtmlElement htmlElement)
            {
                htmlElement.SetAttribute(null, AttributeNames.Lang, "ko-kr");
            }
        }
        //---|

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
                        a.Href = contentCardConfig.RelativePath ?? "";
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

        var formatter = new PrettyMarkupFormatter();
        string result = document.ToHtml(formatter);

        return result;
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

    public static IHtmlDivElement CreateDiv(this IDocument document) => (IHtmlDivElement)document.CreateElement(TagNames.Div);
    public static IHtmlAnchorElement CreateA(this IDocument document) => (IHtmlAnchorElement)document.CreateElement(TagNames.A);

}
