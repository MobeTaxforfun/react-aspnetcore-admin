using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ZoneCore.Models;

namespace ZoneCore.Web.Controllers.Basic
{
    /// <summary>
    /// 用於回應請求的統一規格
    /// 
    /// Successful
    /// Failure
    /// DataChanges 若自定義的 Code 為 1000 前端將自動出現成功提示
    /// ValidationFailure
    /// 
    /// 以上為直接回應 Json
    /// 
    /// Success
    /// Failed
    /// ValidationFailed
    /// 
    /// 以上為回應單純物件
    /// </summary>
    public class ContextController : Controller
    {
        #region 對於 Json 的二次封裝

        /// <summary>
        /// 回應成功
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        public JsonResult Successful(string message = "操作成功") => Json(Success(message: message));

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
                return Json(Success(message: $"{msg}成功", Code: 1000));
            else
                return Json(Failed($"{msg}失敗"));
        }

        /// <summary>
        /// 用於自動回應 Controller ModelStateErrors 的物件
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public JsonResult ValidationFailure(ModelStateDictionary ModelStateErrors) => Json(ValidationFailed(ModelState));

        #endregion

        #region 純粹物件

        /// <summary>
        /// 回應成功(無物件)
        /// </summary>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public MessageAPI Success(string message = "操作成功", int Code = 200)
        {
            return new MessageAPI()
            {
                Status = true,
                Message = message,
                Code = Code
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
        public MessageAPI<T> Success<T>(T data, string message = "操作成功", int Code = 200)
        {
            return new MessageAPI<T>()
            {
                Status = true,
                Message = message,
                Data = data,
                Code = Code
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
                Status = false,
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
                Status = false,
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
                Status = false,
                Message = message,
                ModelStateErrors = ModelStateErrors,
            };
        }

        #endregion
    }
}
