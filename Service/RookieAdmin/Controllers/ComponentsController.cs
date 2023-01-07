using Microsoft.AspNetCore.Mvc;
using RookieAdmin.Controllers.Basic;
using RookieAdmin.Service.Implement.System;
using RookieAdmin.Service.Interface.System;

namespace RookieAdmin.Controllers
{
    public class ComponentsController : BaseAuthController
    {
        private readonly IRoleService _roleSerivce;

        public ComponentsController(IRoleService roleSerivce)
        {
            this._roleSerivce = roleSerivce;
        }

        /// <summary>
        /// Role ddl
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListedRoleddl")]
        public async Task<IActionResult> GetRole()
        {
            return Successful(await _roleSerivce.ListedRoleIdAndName());
        }
    }
}
