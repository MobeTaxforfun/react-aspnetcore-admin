using RookieAdmin.Repository.Interface;
using RookieAdmin.Service.Interface.System;

namespace RookieAdmin.Service.Implement.System
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public List<string> ListedPermissionCodeByRoleId(int RoleId)
        {
            return new List<string>();
        }
    }
}
