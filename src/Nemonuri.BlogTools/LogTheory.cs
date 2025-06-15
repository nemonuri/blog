using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace Nemonuri.BlogTools;

public static partial class LogTheory
{
    private static readonly ILogger<Program> _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Program>();

    public static ILogger Logger => _logger;

    [LoggerMessage(
        LogLevel.Information,
        Message = "Path resolved. Name: {Name}, Path: {Path}")]
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
        Message = "Path resolved. Path: {Path}")]
    public static partial void PathResolved(this ILogger logger, string path);

    [LoggerMessage(
        LogLevel.Information,
        Message = "Directory deleted. Name: {Name}, Path: {Path}")]
    public static partial void DirectoryDeleted(this ILogger logger, string name, string path);

    [LoggerMessage(
        LogLevel.Information,
        Message = "Directory created. Name: {Name}, Path: {Path}")]
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
        Message = "Directory created. Path: {Path}")]
    public static partial void DirectoryCreated(this ILogger logger, string path);

    [LoggerMessage(
        LogLevel.Information,
        Message = "File created. Path: {Path}")]
    public static partial void FileCreated(this ILogger logger, string path);

    [LoggerMessage(
        LogLevel.Information,
        Message = "File mapped. SourceFilePath: {SourceFilePath}, DestFilePath: {DestFilePath}")]
    public static partial void FileMapped(this ILogger logger, string sourceFilePath, string destFilePath);

    public static void FileMapped(this ILogger logger, FileInfo sourceFile, FileInfo destFile) =>
        logger.FileMapped(sourceFile.FullName, destFile.FullName);

}