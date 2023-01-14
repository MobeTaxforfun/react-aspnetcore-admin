using Microsoft.AspNetCore.Mvc;
using ZoneCore.Models.Dto;
using ZoneCore.Models.Model;
using ZoneCore.Web.Controllers.Basic;

namespace ZoneCore.Web.Controllers.System
{
    [Route("System/Role")]
    public class SysRoleController : BaseAuthController
    {
        [HttpGet("Paginate")]
        public IActionResult PaginateRole([FromQuery]RoleSearchParameter model)
        {
            return Successful();
        }

        [HttpGet("{Id}")]
        public IActionResult GetRole(int Id)
        {
            return Successful();
        }

        [HttpPost]
        public IActionResult CreateRole(RoleDto model)
        {
            return Successful();
        }

        [HttpPut]
        public IActionResult UpdateRole(RoleDto model)
        {
            return Successful();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteRole(int Id)
        {
            return Successful();
        }

        [HttpPut("SetStatus")]
        public IActionResult UpdateRoleStatus(RoleDto model)
        {
            return Successful();
        }



    }
}
