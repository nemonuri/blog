using YamlDotNet.Serialization;

namespace Nemonuri.BlogTools;

[YamlSerializable]
public struct DiaryYamlFrontMatterRawData
{
    [YamlMember(Alias = "alias")]
    public string? Alias;

    [YamlMember(Alias = "subindex")]
    public int? Subindex;
}