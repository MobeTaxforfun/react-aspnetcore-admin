using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Entity
{
    public class SysUser
    {
        public long Id { get; set; }
        public string Account { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public short Gender { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public long DepartmentId { get; set; }
        public string Remark { get; set; } = string.Empty;
        public short UserStatus { get; set; }
        public DateTime LastVisitTime { get; set; }
        public bool IsDelete { get; set; }
        public DateTime AuditCreateTime { get; set; }
        public long AuditCreatorId { get; set; }
        public DateTime AuditUpdateTime { get; set; }
        public long AuditUpdaterId { get; set; }
    }
}
