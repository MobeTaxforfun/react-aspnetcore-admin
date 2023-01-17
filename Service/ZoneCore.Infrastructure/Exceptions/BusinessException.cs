using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoneCore.Infra.Exceptions
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
