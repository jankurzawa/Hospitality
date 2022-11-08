namespace Hospitality.Common.Models.Exceptions
{
    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string? message) : base(message) { }
    }
}