using ConsultingCompany.Shared.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ConsultingCompany.API.Factories
{
    public static class ApiResponseFactory
    {
     
        public static IActionResult GenerateApiValidationResponse(ActionContext actionContext)
        {
            var localizer =
                actionContext.HttpContext.RequestServices
                .GetRequiredService<IStringLocalizer<SharedResource>>();

            var Errors = actionContext.ModelState.Where(x => x.Value!.Errors.Count > 0)
                   .ToDictionary(x => x.Key, x => x.Value!.Errors.Select(x => x.ErrorMessage).ToArray());

            var problem = new ProblemDetails()
            {


                Title = localizer[SharedResourcesKeys.ValidationError],
                    

                Detail = localizer[SharedResourcesKeys.ValidationErrorDetail],
                    

                Status = StatusCodes.Status400BadRequest,

                Extensions = { { "Errors", Errors } }



            };


            return new BadRequestObjectResult(problem);

        }
    }
}
