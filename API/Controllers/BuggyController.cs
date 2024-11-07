using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController(DataContext context) : BaseApiController
    {
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetAuth() {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound() {
            var obj = context.Users.Find(-1);

            if (obj == null) return NotFound();

            return obj;
        }

        [HttpGet("server-error")]
        public ActionResult<AppUser> GetServerError() {
            var obj = context.Users.Find(-1) ?? throw new Exception("A Server Error has happened.");

            return obj;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest() {
            return BadRequest("This is a bad request");
        }
    }
}
