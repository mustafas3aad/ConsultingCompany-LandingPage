using ConsultingCompany.BLL.Exceptions.Base;
using ConsultingCompany.Shared.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


namespace ConsultingCompany.API.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ExceptionMiddleware(RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IStringLocalizer<SharedResource> localizer)
        {
            _next = next;
            _logger = logger;
            _localizer = localizer;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
                await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case NotFoundException:
                    case ConflictException:
                    case BadRequestException:
                    case ValidationException:
                        _logger.LogWarning(
                            "Business Exception: {ExceptionType} - {Message}",
                            ex.GetType().Name,
                            ex.Message);
                        break;

                    default:
                        _logger.LogError(ex,
                            "Unhandled Exception: {ExceptionType} - {Message}",
                            ex.GetType().Name,
                            ex.Message);
                        break;
                }

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var problem = new ProblemDetails
            {
                Title = _localizer[SharedResourcesKeys.UnexpectedError],
                    
                Detail = ex.Message,
                Instance = httpContext.Request.Path,
                Status = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    ConflictException => StatusCodes.Status409Conflict,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    ValidationException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                }
            };

            httpContext.Response.StatusCode = problem.Status.Value;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(problem);
        }

        private async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound
                && !httpContext.Response.HasStarted)
            {
                var response = new ProblemDetails
                {
                    Title = _localizer[SharedResourcesKeys.EndpointNotFound],              
                    Detail = _localizer[ SharedResourcesKeys.EndpointNotFound],   
                    Status = StatusCodes.Status404NotFound,
                    Instance = httpContext.Request.Path
                };

                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }

    }
}
