namespace Nemonuri.BlogTools;

public static class CategoryNameTheory
{
    public static string? TranslateCategoryName(string? originalCategoryName)
    {
        return originalCategoryName switch
        {
            Constants.Diary => "일기",
            Constants.StudyJournal => "학습 일지",
            Constants.Idea => "아이디어",
            _ => null
        };
    }
}