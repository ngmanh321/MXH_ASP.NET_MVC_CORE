using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MangXaHoi.Models.Authenlication
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.HttpContext.Session.GetString("DN") == null)
            {     
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller" ,"Access" },
                    {"Action" ,"Login" }
                });
            }


        }
    }
}
