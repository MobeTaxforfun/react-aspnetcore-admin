using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Entity
{
    public class SysMenu : BaseEntity<long>
    {
        public string MenuName { get; set; } = string.Empty;
    }
}
