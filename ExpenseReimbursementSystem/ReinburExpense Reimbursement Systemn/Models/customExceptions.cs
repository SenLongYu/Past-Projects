namespace customExceptions;

public class ResourceNotFoundException : System.Exception 
{
    public ResourceNotFoundException() { }
    public ResourceNotFoundException(string message) : base(message) { }
    public ResourceNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    protected ResourceNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class UsernameNotAvailableException : System.Exception //username already in use
{
    public UsernameNotAvailableException() { }
    public UsernameNotAvailableException(string message) : base(message) { }
    public UsernameNotAvailableException(string message, System.Exception inner) : base(message, inner) { }
    protected UsernameNotAvailableException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class InvalidCredentialsException : System.Exception //password does not match username
{
    public InvalidCredentialsException() { }
    public InvalidCredentialsException(string message) : base(message) { }
    public InvalidCredentialsException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidCredentialsException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class RecordNotFoundException : System.Exception //Specified record does not exist
{
    public RecordNotFoundException() { }
    public RecordNotFoundException(string message) : base(message) { }
    public RecordNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    protected RecordNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}