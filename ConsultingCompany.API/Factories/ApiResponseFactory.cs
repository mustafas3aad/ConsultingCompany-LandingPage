using Microsoft.AspNetCore.Mvc;

namespace ConsultingCompany.API.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult GenerateApiValidationResponse(ActionContext actionContext)
        {
            var Errors = actionContext.ModelState.Where(x => x.Value.Errors.Count > 0)
                   .ToDictionary(x => x.Key, x => x.Value.Errors.Select(x => x.ErrorMessage).ToArray());

            var problem = new ProblemDetails()
            {


                Title = "Validation Errors",

                Detail = "One or more validation error occurred",

                Status = StatusCodes.Status400BadRequest,

                Extensions = { { "Errors", Errors } }



            };


            return new BadRequestObjectResult(problem);

        }
    }
}
