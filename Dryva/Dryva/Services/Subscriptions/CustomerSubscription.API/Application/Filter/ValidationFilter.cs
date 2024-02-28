using System.Linq;
using System.Threading.Tasks;
using CustomerSubscription.API.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerSubscription.API.Application.Filter {
    public class ValidationFilter : IAsyncActionFilter {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            if (!context.ModelState.IsValid) {
                var modelErrors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(vp => vp.Key, vp => vp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();
                
                var errorResponse = new ErrorResponse();
                
                foreach (var (key, enumerable) in modelErrors) {
                    foreach (var value in enumerable) {
                        var errorModel = new ErrorModel(key, value);
                        errorResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            await next();
        }
    }
}