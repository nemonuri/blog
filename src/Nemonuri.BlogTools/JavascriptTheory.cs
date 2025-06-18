using Jint;

namespace Nemonuri.BlogTools;

public static class JavascriptTheory
{
    private static Engine? _syntaxHighlighterEngine = null;
    private static Engine SyntaxHighlighterEngine => _syntaxHighlighterEngine ??=
        new Engine().Execute
        (
            File.ReadAllText
            (
                Path.Combine(AppContext.BaseDirectory, Constants.JavascriptModule, "syntaxHighlighter.js")
            )
        );

    public static string HighlightSyntax(string code, string language)
    {
        var jsValue = SyntaxHighlighterEngine.Evaluate($"""
        SyntaxHighlighter.highlightSyntax({code}, {language})
        """);

        return jsValue.AsString();
    }
    

}
