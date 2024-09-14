namespace PlanY.Presentation.Http;

public class BaseHttpResponse<T>
{
    public HttpStatus HttpStatus { get; set; }
    public string Messages { get; set; } = "";
    public T? ResponseObject { get; set; }

    public static BaseHttpResponse<T> Success(T item)
    {
        return new BaseHttpResponse<T>
        {
            HttpStatus = HttpStatus.Ok,
            Messages = "Ok",
            ResponseObject = item
        };
    }

    public static BaseHttpResponse<T> BadRequest()
    {
        return new BaseHttpResponse<T>
        {
            HttpStatus = HttpStatus.BadRequest,
            Messages = "Bad request"
        };
    }

    public static BaseHttpResponse<T> Unauthorized()
    {
        return new BaseHttpResponse<T>
        {
            HttpStatus = HttpStatus.Unauthorized,
            Messages = "Unauthorized"
        };
    }

    public static BaseHttpResponse<T> Forbidden(T item)
    {
        return new BaseHttpResponse<T>
        {
            HttpStatus = HttpStatus.Forbidden,
            Messages = "Forbidden",
            ResponseObject = item
        };
    }

    public static BaseHttpResponse<T> NotFound(T item)
    {
        return new BaseHttpResponse<T>
        {
            HttpStatus = HttpStatus.NotFound,
            Messages = "Not Found",
            ResponseObject = item
        };
    }
}