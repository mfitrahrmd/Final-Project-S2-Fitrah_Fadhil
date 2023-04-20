namespace API.DTOs.response;

public class BaseResponse<T>
{
    public int Code { get; set; }
    public bool IsSucceeded { get; set; }
    public string Message { get; set; }
    public object Errors { get; set; }
    public T Data { get; set; }
}