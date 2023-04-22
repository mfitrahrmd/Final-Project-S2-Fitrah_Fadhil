using API.DTOs.response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Extensions.Filters;

public class ResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var objectResult = context.Result as ObjectResult;

        objectResult.Value = new BaseResponse<object>
        {
            Code = objectResult.StatusCode.Value,
            IsSucceeded = true,
            Data = objectResult.Value
        };

        await next();
    }
}