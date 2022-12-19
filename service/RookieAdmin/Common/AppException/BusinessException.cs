namespace RookieAdmin.Common.AppException
{
    /// <summary>
    /// 先自訂一個 Exception 之後方便擴展
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message)
          : base(message)
        {

        }
    }
}
