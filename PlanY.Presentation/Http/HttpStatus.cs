namespace PlanY.Presentation.Http;

[Flags]
public enum HttpStatus
{
    Ok = 200,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
}