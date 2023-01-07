using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RookieAdmin.Models;

namespace RookieAdmin.Common.Attributes
{
    /// <summary>
    /// 自動回應模型錯誤
    /// </summary>
    public class GlobalModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            MessageValidFailed message = new MessageValidFailed()
            {
                Status = false,
                Message = "欄位錯誤",
                Code = 409,
                ModelStateErrors = context.ModelState.Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray())
            };

            context.Result = new JsonResult(message);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //沒用到的東西
        }
    }
}
