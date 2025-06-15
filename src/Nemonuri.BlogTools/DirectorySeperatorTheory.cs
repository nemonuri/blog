namespace Nemonuri.BlogTools;

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

            if (Array.IndexOf(_wellKnownPathSeparators, currentPathChar) >= 0)
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