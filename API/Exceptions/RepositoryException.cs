namespace API.Exceptions;

public enum RepositoryErrorType
{
    NotFound
}

public class RepositoryException : Exception
{
    public RepositoryErrorType ErrorType { get; set; }
    
    public RepositoryException(RepositoryErrorType errorType, string message) : base(message)
    {
        ErrorType = errorType;
    }
}