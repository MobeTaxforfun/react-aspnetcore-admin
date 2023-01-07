using Microsoft.AspNetCore.Mvc;
using RookieAdmin.Controllers.Basic;
using RookieAdmin.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace RookieAdmin.Controllers.System
{
    public class AxiosDemoController : BasicController
    {
        [HttpGet("Successful")]
        public IActionResult GetSuccessful()
        {
            return Successful();
        }

        [HttpGet("Failed")]
        public IActionResult GetFailed()
        {
            return Failure();
        }

        [HttpGet("TraceUnauthorized")]
        public IActionResult TraceUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("TraceForbid")]
        public IActionResult TraceForbid()
        {
            return Forbid();
        }

        [HttpGet("TraceBadRequest")]
        public IActionResult TraceBadRequest()
        {
            return BadRequest();
        }


        [HttpPost("Create")]
        public IActionResult CreateDemo([FromBody] CreateDemoVM model)
        {
            return DataChanges(1, "新增");
        }

        [HttpPost("CreateValidate")]
        public IActionResult CreateValidate([FromForm] CreateValidateVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(ValidationFailed(ModelState));
            }

            return DataChanges(1, "新增");
        }

        [HttpPost("CreateValidateSummary")]
        public IActionResult CreateSummary([FromForm] CreateDemoVM model)
        {
            ModelState.AddModelError("Summary", "這裡有一個錯誤");
            return Json(ValidationFailed(ModelState));
        }
    }

    public class CreateDemoVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateValidateVM
    {
        [Required(ErrorMessage = "Id 為必填")]
        [Range(1, 10, ErrorMessage = "數字必定為 1- 10 ")]
        public int? Id { get; set; } = -1;
        [Required(ErrorMessage = "名稱為必填")]
        public string Name { get; set; } = null!;
    }
}
