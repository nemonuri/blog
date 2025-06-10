using AngleSharp;
using AngleSharp.Text;
using AngleSharp.Dom;
using AngleSharp.Html.Construction;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;

namespace Nemonuri.BlogTools;

public static class HtmlTheory
{
    public static string CreateIndexHtml()
    {
        IBrowsingContext context = BrowsingContext.New();
        string basicHtmlText = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "html-template", "basic.html"));
        IDocument document = context.OpenAsync(req => req.Content(basicHtmlText)).Result;

        document.Title = "네모누리의 블로그";

        //--- 언어를 한국어로 설정 ---
        IHtmlMetaElement langMetaElement =
            document.Head?.ChildNodes?.OfType<IHtmlMetaElement>()?.LastOrDefault(m => m.HasAttribute(AttributeNames.Lang))
            ?? document.CreateMetaElementAndAppendToHead();

        langMetaElement.SetAttribute(null, AttributeNames.Lang, "ko-kr");
        //---|

        string result = document.ToHtml();

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



}
