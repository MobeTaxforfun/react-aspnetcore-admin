using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Service.Contract
{
    public interface IService
    {
        Task CreateUser();
        Task UpdateUser();
        Task DeleteUser();
        
    }
}
