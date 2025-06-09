using Markdig;

MarkdownPipelineBuilder pipeline = new MarkdownPipelineBuilder().UseYamlFrontMatter();
//var result = Markdown.ToHtml()