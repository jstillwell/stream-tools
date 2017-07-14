using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StreamTools.Models;

namespace stream_tools.Controllers {
    /// <summary>
    /// Handles creating social media links
    /// </summary>
    [Route("api/[controller]")]
    public class SocialController : Controller {
        private readonly StreamTools.IViewRenderService _viewRenderService;
        public SocialController(StreamTools.IViewRenderService viewRenderService) {
            _viewRenderService = viewRenderService;
        }

        /// <summary>
        /// creates a banner with links to various social media sites
        /// </summary>
        /// <param name="twitter">your twitter handle</param>
        /// <param name="youtube">your youtube channel</param>
        /// <returns></returns>
        [HttpGet("{twitter}/{youtube}")]
        [ProducesResponseType(typeof(ActionResult), 200)]
        public async Task<ActionResult> Get(string twitter = "", string youtube = "") {
            //TODO: connect this to users and a DB of some kind so that we can have multiple users and they can customize the look and which elements show.
            var model = new Social { Twitter = twitter, YouTube = youtube, Facebook = "" };
            var content = await _viewRenderService.RenderToStringAsync("Social", model);

            return Content(content, "text/html");
        }
        
    }
}
