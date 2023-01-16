using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoneCore.Infra.DataAccess.Model
{
    public class PaginateModel<Entity> where Entity : class
    {
        public int Max { get; set; }
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public List<Entity>? Result { get; set; } = null;
    }
}
