namespace Tmf683.PartyInteraction.Application.Common;
public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T Result { get; set; }
    public int StatusCode { get; set; }
    public List<string> ErrorMessages { get; set; } = new List<string>();

    public static ApiResponse<T> Success(T result, int statusCode = 200)
    {
        return new ApiResponse<T> { IsSuccess = true, Result = result, StatusCode = statusCode };
    }

    public static ApiResponse<T> Fail(string errorMessage, int statusCode = 400)
    {
        return new ApiResponse<T> { IsSuccess = false, ErrorMessages = new List<string> { errorMessage }, StatusCode = statusCode };
    }

    public static ApiResponse<T> Fail(List<string> errorMessages, int statusCode = 400)
    {
        return new ApiResponse<T> { IsSuccess = false, ErrorMessages = errorMessages, StatusCode = statusCode };
    }
}