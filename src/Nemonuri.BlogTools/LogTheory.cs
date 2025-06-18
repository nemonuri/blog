using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace Nemonuri.BlogTools;

public static partial class LogTheory
{
    private static readonly ILogger<Program> _logger = LoggerFactory.Create(ConfigLoggingBuilder).CreateLogger<Program>();

    private static void ConfigLoggingBuilder(ILoggingBuilder builder)
    {
        builder.AddConsole();

        builder.SetMinimumLevel
        (
#if DEBUG_LOG
            LogLevel.Debug
#else
            LogLevel.Information
#endif
        );
    }

    public static ILogger Logger => _logger;

    [LoggerMessage(
        LogLevel.Information,
        Message = """
        Path resolved. 
        - Name: {Name}, 
        - Path: {Path}
        """)]
    public static partial void PathResolved(this ILogger logger, string name, string path);

    public static void PathResolved
    (
        this ILogger logger,
        FileSystemInfo fileSystemInfo,
        [CallerArgumentExpression(nameof(fileSystemInfo))] string callerExpression = ""
    ) =>
        logger.PathResolved(callerExpression, fileSystemInfo.FullName);

    [LoggerMessage(
        LogLevel.Information,
        Message = """
        Path resolved. 
        - Path: {Path}
        """)]
    public static partial void PathResolved(this ILogger logger, string path);

    [LoggerMessage(
        LogLevel.Information,
        Message = """
        Directory deleted. 
        - Name: {Name}, 
        - Path: {Path}
        """)]
    public static partial void DirectoryDeleted(this ILogger logger, string name, string path);

    [LoggerMessage(
        LogLevel.Information,
        Message = """
        Directory created. 
        - Name: {Name}, 
        - Path: {Path}
        """)]
    public static partial void DirectoryCreated(this ILogger logger, string name, string path);

    public static void DirectoryCreated
    (
        this ILogger logger,
        DirectoryInfo directoryInfo,
        [CallerArgumentExpression(nameof(directoryInfo))] string callerExpression = ""
    ) =>
        logger.DirectoryCreated(callerExpression, directoryInfo.FullName);

    [LoggerMessage(
        LogLevel.Information,
        Message = """
        Directory created. 
        - Path: {Path}
        """)]
    public static partial void DirectoryCreated(this ILogger logger, string path);

    [LoggerMessage(
        LogLevel.Information,
        Message = """
        File created. 
        - Path: {Path}
        """)]
    public static partial void FileCreated(this ILogger logger, string path);

    [LoggerMessage(
        LogLevel.Information,
        Message = """
        File mapped. 
        SourceFilePath: {SourceFilePath}, 
        DestFilePath: {DestFilePath}
        """)]
    public static partial void FileMapped(this ILogger logger, string sourceFilePath, string destFilePath);

    public static void FileMapped(this ILogger logger, FileInfo sourceFile, FileInfo destFile) =>
        logger.FileMapped(sourceFile.FullName, destFile.FullName);

    [LoggerMessage(
        LogLevel.Debug,
        Message = """
        Markdown converted to HTML. 
        HTML:
        {Html}
        """)]
    public static partial void MarkdownConvertedToHtml(this ILogger logger, string html);

    [LoggerMessage(
        LogLevel.Debug,
        Message = """
        Evaluating javscript code. 
        Module: {Module}
        Code:
        {Code}
        """)]
    public static partial void JavscriptCodeEvaluating(this ILogger logger, string module, string code);

    [LoggerMessage(
        LogLevel.Debug,
        Message = """
        Javscript code evaluated. 
        Result: {Result}
        """)]
    public static partial void JavscriptCodeEvaluated(this ILogger logger, string result);

}