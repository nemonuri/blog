using Jint;
using Jint.Native;

namespace Nemonuri.BlogTools;

public static class JavascriptTheory
{
    private static Engine? _syntaxHighlighterEngine = null;
    private static Engine SyntaxHighlighterEngine => _syntaxHighlighterEngine ??=
        new Engine()
        .SetValue("__console_log", new Action<object>(Console.WriteLine))
        .SetValue("__console_warn", new Action<object>(Console.WriteLine))
        .SetValue("__console_error", new Action<object>(Console.Error.WriteLine))
        .Execute("""
        const console = {
            log: __console_log,
            warn: __console_warn,
            error: __console_error
        }
        """)
        .Execute
        (
            File.ReadAllText
            (
                Path.Combine(AppContext.BaseDirectory, Constants.JavascriptModule, "syntaxHighlighter.js")
            )
        );

    public static string HighlightSyntax(string code, string language, out bool languageExists)
    {
        languageExists = IsLanguageExist(language);
        LogTheory.Logger.LanguageExistsInHighlightJsTested(language, languageExists);

        if (!languageExists)
        {
            return code;
        }

        string escapedCode = $"""
        SyntaxHighlighter.highlightSyntax("{EscapeString(code)}", "{language}")
        """;

        LogTheory.Logger.JavscriptCodeEvaluating("syntaxHighlighter.js", escapedCode);

        var jsValue = SyntaxHighlighterEngine.Evaluate(escapedCode);

        string result = jsValue.AsString();
        LogTheory.Logger.JavscriptCodeEvaluated(result);

        return result;
    }

    public static bool IsLanguageExist(string language)
    {
        var jsValue = SyntaxHighlighterEngine.Evaluate($"""
        SyntaxHighlighter.isLanguageExist("{language}")
        """);

        return jsValue.AsBoolean();
    }

    private static readonly char[] _escapeTargetChars = ['\t', '\b', '\n', '\r', '\f', '\0', '\v', '\'', '\"', '\\'];
    private static readonly string[] _escapedResultStrings = ["""\t""", """\b""", """\n""", """\r""", """\f""", """\0""", """\v""", """\'""", "\\\"", """\\"""];
    private static readonly Dictionary<char, string> _escapeTargetAndResultMap = _escapeTargetChars
        .Zip(_escapedResultStrings)
        .ToDictionary(keySelector: p => p.First, elementSelector: p => p.Second);

    public static string EscapeString(string source)
    {
        int escapeTargetCharsInSourceCount = 0;
        foreach (var c in source)
        {
            if (Array.IndexOf(_escapeTargetChars, c) >= 0) { escapeTargetCharsInSourceCount++; }
        }

        int escapedStringLength = source.Length + escapeTargetCharsInSourceCount;
        Span<char> escapedSpan = stackalloc char[escapedStringLength];

        int spanPos = 0;
        for (int i = 0; i < source.Length; i++)
        {
            char sourceChar = source[i];
            if (_escapeTargetAndResultMap.TryGetValue(sourceChar, out string? resultString))
            {
                for (int i2 = 0; i2 < resultString.Length; i2++)
                {
                    escapedSpan[spanPos] = resultString[i2];
                    spanPos++;
                }
            }
            else
            {
                escapedSpan[spanPos] = sourceChar;
                spanPos++;
            }
        }

        return new string(escapedSpan);
    }
    

}
