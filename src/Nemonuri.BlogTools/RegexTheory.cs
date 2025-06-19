using System.Text.RegularExpressions;

namespace Nemonuri.BlogTools;

public static partial class RegexTheory
{
    [GeneratedRegex("""(?<Date>\d\d\d\d-\d\d-\d\d)( (?<Title>.*))?""", RegexOptions.ECMAScript, "ko-kr")]
    public static partial Regex GetDiaryNameRegex();

    [GeneratedRegex("""language-(?<LanguageName>.*)""", RegexOptions.ECMAScript | RegexOptions.IgnoreCase, "en-us")]
    public static partial Regex GetLanguageNameRegex();

    [GeneratedRegex("""&(?<Key>[a-z]+);""", RegexOptions.ECMAScript | RegexOptions.IgnoreCase, "en-us")]
    public static partial Regex GetHtmlEscapeRegex();
}