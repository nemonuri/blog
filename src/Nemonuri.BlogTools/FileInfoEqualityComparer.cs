using System.Diagnostics.CodeAnalysis;

namespace Nemonuri.BlogTools;

public class FileInfoEqualityComparer() : IEqualityComparer<FileInfo>
{
    public bool Equals(FileInfo? x, FileInfo? y)
    {
        if (!(x?.FullName is { } xName && y?.FullName is { } yName))
        {
            return false;
        }

        return xName.Equals(yName);
    }

    public int GetHashCode([DisallowNull] FileInfo obj)
    {
        return obj?.FullName.GetHashCode() ?? 0;
    }
}