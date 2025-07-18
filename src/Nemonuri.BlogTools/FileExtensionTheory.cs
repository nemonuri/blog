namespace Nemonuri.BlogTools;

public static class FileExtensionTheory
{
    /// <summary>
    /// 원본 파일 경로의 확장자를 새 것으로 교체합니다.
    /// </summary>
    /// <param name="originalPath">원본 파일 경로</param>
    /// <param name="extension">교체할 새 확장자</param>
    /// <returns>확장자가 교체된 파일 경로</returns>
    public static string ChangeExtension(string originalPath, string? extension)
    {
        int lastDotIndex = originalPath.LastIndexOf('.');
        if (lastDotIndex == -1)
        {
            return string.Concat(originalPath, extension);
        }
        else
        {
            return string.Concat(originalPath.AsSpan(0, lastDotIndex), extension);
        }
    }

    public static string RemoveExtension(string originalPath) => ChangeExtension(originalPath, string.Empty);
}
