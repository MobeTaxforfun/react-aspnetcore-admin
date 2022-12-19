using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RookieAdmin.Models;

namespace RookieAdmin.Controllers.Basic
{
    [ApiController]
    [Route("api/[controller]")]
    //[Produces("application/json")]
    public class ContextController : Controller
    {
        #region 對於 Json 的二次封裝

        /// <summary>
        /// 回應成功
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        public JsonResult Successful(string message = "操作成功") => Json(Success(message));

        /// <summary>
        /// 回應成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        public JsonResult Successful<T>(T data, string message = "操作成功") => Json(Success(data, message));

        /// <summary>
        /// 回應失敗
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        public JsonResult Failure(string message = "操作失敗") => Json(Failed(message));

        /// <summary>
        /// 回應失敗
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        public JsonResult Failure<T>(T data, string message = "操作失敗") => Json(Failed(data, message));

        /// <summary>
        /// 用於自動回應是否變更成功
        /// </summary>
        /// <param name="dbCount"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [NonAction]
        public JsonResult DataChanges(int dbCount, string msg)
        {
            if (dbCount > 0)
                return Json(Success($"{msg}成功"));
            else
                return Json(Failed($"{msg}失敗"));
        }

        #endregion

        /// <summary>
        /// 回應成功(無物件)
        /// </summary>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public MessageAPI Success(string message = "操作成功")
        {
            return new MessageAPI()
            {
                Success = true,
                Message = message,
                Status = 200
            };
        }

        /// <summary>
        /// 回應成功(有物件)
        /// </summary>
        /// <typeparam name="T">型態</typeparam>
        /// <param name="data">回傳結果</param>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public MessageAPI<T> Success<T>(T data, string message = "操作成功")
        {
            return new MessageAPI<T>()
            {
                Success = true,
                Message = message,
                Data = data,
                Status = 200
            };
        }

        /// <summary>
        /// 回應失敗(無物件)
        /// </summary>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public MessageAPI Failed(string message = "操作失敗")
        {
            return new MessageAPI()
            {
                Success = false,
                Message = message,
            };
        }

        /// <summary>
        /// 回應失敗(有物件)
        /// </summary>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public MessageAPI<T> Failed<T>(T data, string message = "操作失敗")
        {
            return new MessageAPI<T>()
            {
                Success = false,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 未通過資料驗證 (純粹 ModelStateErrors)
        /// </summary>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public MessageValidFailed ValidationFailed(ModelStateDictionary ModelStateErrors, string message = "欄位錯誤")
        {
            return ValidationFailed(
                ModelStateErrors.Where(x => x.Value != null && x.Value.Errors.Count > 0)
                .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray()), message);
        }

        /// <summary>
        /// 未通過資料驗證 (整理成 dic)
        /// </summary>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public MessageValidFailed ValidationFailed(Dictionary<string, string[]> ModelStateErrors, string message = "欄位錯誤")
        {
            return new MessageValidFailed()
            {
                Success = false,
                Message = message,
                ModelStateErrors = ModelStateErrors,
            };
        }
    }
}
