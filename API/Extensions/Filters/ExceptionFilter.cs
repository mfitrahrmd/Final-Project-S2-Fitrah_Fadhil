using System.Net;
using API.DTOs.response;
using API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Extensions.Filters;

public class ExceptionFilter : ExceptionFilterAttribute
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }

    public override async Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.ExceptionHandled)
            return;

        var result = new ObjectResult(new { });

        switch (context.Exception)
        {
            case ApiException e:
                result.Value = new BaseResponse<object>
                {
                    Code = e.Code,
                    IsSucceeded = false,
                    Message = e.Message,
                    Errors = e.Errors
                };
                result.StatusCode = e.Code;
                break;
            case RepositoryException e:
                switch (e.ErrorType)
                {
                    case RepositoryErrorType.NotFound:
                        result.Value = new BaseResponse<object>()
                        {
                            Code = (int)HttpStatusCode.NotFound,
                            IsSucceeded = false,
                            Message = e.Message,
                        };
                        result.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                }
                break;
            default:
                _logger.LogError(
                    $"{nameof(ExceptionFilter)} : Error in {context.ActionDescriptor.DisplayName}. {context.Exception.Message}. Stack Trace : {context.Exception.StackTrace}");

                result.Value = new BaseResponse<object>
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    IsSucceeded = false,
                    Message = "Unexpected server error, please try again later.",
                };
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        context.Result = result;
    }
}