using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RookieAdmin.Models.Model.Search
{
    public class RoleSearchModel : PageParameterModel
    {
        public string RoleName { get; set; } = null!;
        public string RoleCode { get; set; } = null!;
        public int? Status { get; set; }
    }
}
