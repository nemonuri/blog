using System.Text.RegularExpressions;

namespace Nemonuri.BlogTools;

public static partial class RegexTheory
{
    [GeneratedRegex("""(?<Date>\d\d\d\d-\d\d-\d\d)( (?<Title>.*))?""", RegexOptions.ECMAScript, "ko-kr")]
    public static partial Regex GetDiaryNameRegex();
}