using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Infra.DataAccess.EFCore.Context;
using ZoneCore.Infra.DataAccess.EFCore.Query;

namespace ZoneCore.Infra.DataAccess.EFCore
{
    /// <summary>
    /// 針對 EF 操作擴展, EFExecute 為增刪改, EFQuery 為各種查詢
    /// </summary>
    public interface IRepository : IGenericEFExecute, IGenericEFQuery
    {
    }
}
