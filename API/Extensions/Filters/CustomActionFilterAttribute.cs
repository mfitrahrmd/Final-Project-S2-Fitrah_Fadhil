using System.Net;
using API.DTOs.response;
using API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Extensions.Filters;

public class CustomActionFilterAttribute : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
            return;

        var errors = new Dictionary<string, object>();

        foreach (var err in context.ModelState)
        {
            errors[err.Key] = err.Value.Errors.Select(e => e.ErrorMessage);
        }

        throw new ApiException("Validation error.")
        {
            Code = (int)HttpStatusCode.BadRequest,
            Errors = errors
        };
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is null || !context.ModelState.IsValid || context.Exception is not null)
            return;
        
        var or = (ObjectResult)context.Result;

        or.Value = new BaseResponse<object>
        {
            Code = or.StatusCode.Value,
            IsSucceeded = true,
            Data = or.Value
        };

        context.Result = or;
    }
}