public enum AnswerCategories
{
    LOCATION, ACTION, COMPANION, NULL
}

public class AnswerOption
{
    public string title;
    public AnswerCategories category;

    public AnswerOption() { }

    public AnswerOption(string title, AnswerCategories category)
    {
        this.title = title;
        this.category = category;
    }

    public string GetAnswerData()
    {
        string message;

        message = string.Format("Title: {0}, Categort: {1}", title, category);
            
        return message;
    }
}