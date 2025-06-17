import hljs, { HighlightOptions, HighlightResult } from 'highlight.js';

export function highlightSyntax(code: string, language: string): string
{
    let highlightOptions: HighlightOptions = {
        language: language,
        ignoreIllegals: false
    };
    let result: HighlightResult = hljs.highlight(code, highlightOptions);
    return result.value;
}
