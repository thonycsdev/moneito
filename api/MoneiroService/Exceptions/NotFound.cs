namespace MoneiroService.Exceptions;

public class NotFoundException(string resourceName, object id)
    : Exception($"{resourceName} with id '{id}' was not found")
{
    public string ResourceName { get; } = resourceName;
    public object Id { get; } = id;
    public string ErrorCode { get; } = "RESOURCE_NOT_FOUND";
}