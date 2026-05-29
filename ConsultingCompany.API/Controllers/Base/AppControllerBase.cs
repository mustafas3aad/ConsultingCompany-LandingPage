using ConsultingCompany.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConsultingCompany.API.Base
{
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        protected ObjectResult NewResult<T>(Response<T> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK
                    => new OkObjectResult(response),

                HttpStatusCode.Created
                    => new CreatedResult(string.Empty, response),

                HttpStatusCode.BadRequest
                    => new BadRequestObjectResult(response),

                HttpStatusCode.NotFound
                    => new NotFoundObjectResult(response),

                HttpStatusCode.Unauthorized
                    => new UnauthorizedObjectResult(response),

                HttpStatusCode.UnprocessableEntity
                    => new UnprocessableEntityObjectResult(response),

                _ => new BadRequestObjectResult(response)
            };
        }
    }
}
