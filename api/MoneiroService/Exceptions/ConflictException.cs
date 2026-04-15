namespace MoneiroService.Exceptions;

public class ConflictException(string resourceName, string field, object value)
    : Exception($"{resourceName} with {field} '{value}' already exists")
{
    public string ResourceName { get; } = resourceName;
    public string Field { get; } = field;
    public object Value { get; } = value;
    public string ErrorCode { get; } = "RESOURCE_CONFLICT";
}
