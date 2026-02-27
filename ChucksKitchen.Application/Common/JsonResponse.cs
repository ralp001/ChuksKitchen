namespace ChuksKitchen.Application.Common;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static Result<T> Success(T data, string message = "") =>
        new() { IsSuccess = true, Data = data, Message = message };

    public static Result<T> Failure(string message) =>
        new() { IsSuccess = false, Message = message };
}