namespace AIService.Prompts;

public static class AnalyzeErrorPrompt
{
    public static string Build(string error)
    {
        return $@"
            You are a senior .NET developer.

            Analyze the error and explain:
            - cause
            - fix
            - steps

            ERROR:
            {error}
            ";
    }
}