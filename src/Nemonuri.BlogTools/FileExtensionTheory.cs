namespace Nemonuri.BlogTools;

public static class FileExtensionTheory
{
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

public static class DirectorySeperatorTheory
{
    public const char UriStyleDirectorySeperator = '/';

    private static readonly char[] _wellKnownPathSeparators = [UriStyleDirectorySeperator, Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar];

    public static string ReplacePathSeperatorsWithUriStyle(string path)
    {
        Span<char> resultSpan = stackalloc char[path.Length];
        for (int i = 0; i < resultSpan.Length; i++)
        {
            char currentPathChar = path[i];

            if (Array.IndexOf(_wellKnownPathSeparators, currentPathChar) < 0)
            {
                resultSpan[i] = UriStyleDirectorySeperator;
            }
            else
            {
                resultSpan[i] = currentPathChar;
            }
        }

        return new string(resultSpan);
    }
}