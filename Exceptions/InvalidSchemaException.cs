namespace DanyTCG.Exceptions;

public class InvalidSchemaException : Exception
{
    public string FieldName { get; }
    public bool DisplayToUser { get; }

    public InvalidSchemaException(string message, string? fieldName = null, bool displayToUser = false) : base(message)
    {
        FieldName = fieldName ?? string.Empty;
        DisplayToUser = displayToUser;
    }
}