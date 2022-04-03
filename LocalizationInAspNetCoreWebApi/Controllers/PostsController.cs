using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationInAspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        protected readonly IStringLocalizer<PostsController> ControllerLocalizer;
        protected readonly IStringLocalizer SharedLocalizer;

        public PostsController(IStringLocalizer<PostsController> controllerLocalizer, IStringLocalizer sharedLocalizer)
        {
            ControllerLocalizer = controllerLocalizer;
            SharedLocalizer = sharedLocalizer;
        }

        [HttpGet, Route("PostsControllerResource")]
        public IActionResult GetUsingPostsControllerResource()
        {
            return Ok(new
            {
                PostType = ControllerLocalizer["Article"].Value,
                PostName = ControllerLocalizer["Welcome"].Value
            });
        }

        [HttpGet, Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            return Ok(new
            {
                Hello = SharedLocalizer["Hello"].Value
            });
        }
    }
}
