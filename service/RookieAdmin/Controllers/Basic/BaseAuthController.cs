using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RookieAdmin.Controllers.Basic
{
    // 這裡放 JWT
    [Authorize]
    public class BaseAuthController : BasicController
    {

    }
}
