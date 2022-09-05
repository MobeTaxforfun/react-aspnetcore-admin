using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Dto.Dto
{
    public class SysUserDto
    {
        public long Id { get; set; }
        public string Account { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long RoleId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
