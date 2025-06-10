using YamlDotNet.Serialization;

namespace Nemonuri.BlogTools;

[YamlSerializable]
public struct YamlFrontMatterRawData
{
    [YamlMember(Alias = "title")]
    public string? Title;

    [YamlMember(Alias = "date")]
    public DateTime Date;

    [YamlMember(Alias = "daily_index")]
    public int? DailyIndex;
}