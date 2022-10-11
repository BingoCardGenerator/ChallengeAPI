using Microsoft.AspNetCore.Mvc;

namespace ChallengeApi.Controllers
{
    public class ChallengeApiController : ControllerBase
    {
        protected IActionResult GetActionResult<T>(ServiceResponse<T> serviceresponse) where T : class
        {
            if (serviceresponse is null)
            {
                throw new ArgumentNullException(nameof(serviceresponse));
            }

            return serviceresponse.ServiceResultCode switch
            {
                ServiceResultCode.Ok => Ok(serviceresponse.Data),
                ServiceResultCode.NotFound => NotFound(),
                ServiceResultCode.BadRequest => BadRequest(serviceresponse.Message),
                _ => throw new InvalidOperationException("Server Error: Unexpected service response")
            };
        }

        protected IActionResult GetActionResult(ServiceResponse serviceresponse)
        {
            if (serviceresponse is null)
            {
                throw new ArgumentNullException(nameof(serviceresponse));
            }

            return serviceresponse.ServiceResultCode switch
            {
                ServiceResultCode.Ok => NoContent(),
                ServiceResultCode.NotFound => NotFound(),
                ServiceResultCode.BadRequest => BadRequest(serviceresponse.Message),
                _ => throw new InvalidOperationException("Server Error: Unexpected service response")
            };
        }
    }
}
