namespace Core.Common;

public class Result(
    bool isSuccess,
    string clientMessage,
    string error)
{
    public bool IsSuccess { get; } = isSuccess;
    public bool IsFailure => !IsSuccess;
    public string Error { get; } = error;
    public string ClientMessage { get; } = clientMessage;

    public static Result Success(string clientMessage = "") => new(true, clientMessage,string.Empty);
    public static Result Failure(string error, string clientMessage = "") => new(false, clientMessage , error);
}

public class Result<T>(
    bool isSuccess, 
    T? value,
    string error)
{
    public T? Value { get; } = value; 
    public bool IsSuccess { get; } = isSuccess;
    public bool IsFailure => !IsSuccess;
    public string Error { get; } = error;

    public static Result<T> Success(T? value) => new(true, value, string.Empty);
    public static Result<T> Failure(string error) => new(false, default, error);
}
