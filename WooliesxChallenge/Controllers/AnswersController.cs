using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WooliesxChallenge.Application;
using WooliesxChallenge.Domain;

namespace WooliesxChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IUserService _userService;

        public AnswersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserModel> Get()
        {
            var userModel = _userService.GetUser();
            return Ok(userModel);
        }
    }
}
