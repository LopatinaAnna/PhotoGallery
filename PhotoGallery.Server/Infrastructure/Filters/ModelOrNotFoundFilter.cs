using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PhotoGallery.Server.Infrastructure.Filters
{
    public class ModelOrNotFoundFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult result)
            {
                var model = result.Value;
                if (model is null)
                {
                    context.Result = new NotFoundResult();
                }
            }
        }
    }
}