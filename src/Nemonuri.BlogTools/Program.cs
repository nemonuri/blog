using Markdig;

MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

string docDirectoryPath = Path.Combine(AppContext.BaseDirectory, "doc");

foreach (string filePath in Directory.EnumerateFiles(docDirectoryPath, "*.md", SearchOption.AllDirectories))
{
    string markDownText = File.ReadAllText(filePath);
    var result = Markdown.ToHtml(markDownText, pipeline);
    Console.WriteLine(filePath);
    Console.WriteLine(result);
}