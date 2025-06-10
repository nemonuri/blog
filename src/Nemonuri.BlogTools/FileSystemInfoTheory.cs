namespace Nemonuri.BlogTools;

public static class FileSystemInfoTheory
{
    public static DirectoryInfo? GetParentDirectoryIfNotExists(this FileInfo fileInfo)
    {
        if (fileInfo.Directory is { } parentDirectory && !parentDirectory.Exists)
        {
            return parentDirectory;
        }
        else
        {
            return null;
        }
    }
}