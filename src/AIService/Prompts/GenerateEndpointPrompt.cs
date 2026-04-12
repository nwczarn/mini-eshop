namespace AIService.Prompts;

public static class GenerateEndpointPrompt
{
    public static string Build(string spec)
    {
        return $@"
            You are a senior .NET developer.

            Generate a minimal API endpoint.

            Return only code.

            SPEC:
            {spec}
            ";
    }
}