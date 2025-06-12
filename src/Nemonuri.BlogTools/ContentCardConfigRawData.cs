namespace Nemonuri.BlogTools;

/// <summary>
/// 콘텐츠 카드 설정 데이터입니다.
/// </summary>
public struct ContentCardConfigRawData
{
    public string? Title;

    public DateTime Date;

    public int? Subindex;

    public string? Category;

    public string? RelativeHtmlPath;

    public string? ErrorMessage;
}

public class ContentCardConfigRawDataComparer(): IComparer<ContentCardConfigRawData>
{
    public int Compare(ContentCardConfigRawData x, ContentCardConfigRawData y)
    {
        if (x.Date != y.Date)
        {
            return x.Date.CompareTo(y.Date);
        }

        return GetDailyIndexOrMinusOne(ref x).CompareTo(GetDailyIndexOrMinusOne(ref y));

        static int GetDailyIndexOrMinusOne(ref ContentCardConfigRawData x)
        {
            return x.Subindex ?? -1;
        }
    }
}