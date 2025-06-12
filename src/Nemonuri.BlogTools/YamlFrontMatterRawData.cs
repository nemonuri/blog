using YamlDotNet.Serialization;

namespace Nemonuri.BlogTools;

#if false
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
#endif

[YamlSerializable]
public struct DiaryYamlFrontMatterRawData
{
    [YamlMember(Alias = "alias")]
    public string? Alias;

    [YamlMember(Alias = "subindex")]
    public int? Subindex;
}