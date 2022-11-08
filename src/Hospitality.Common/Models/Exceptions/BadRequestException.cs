namespace Hospitality.Common.Models.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException(string? message) : base(message) { }
    }
}