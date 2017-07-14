using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StreamTools.Models;

namespace stream_tools.Controllers {
    [Route("api/[controller]")]
    public class SocialController : Controller {
        private readonly StreamTools.IViewRenderService _viewRenderService;
        public SocialController(StreamTools.IViewRenderService viewRenderService) {
            _viewRenderService = viewRenderService;
        }

        // GET api/values/5
        [HttpGet("{twitter}/{youtube}")]
        public async Task<ActionResult> Get(string twitter = "", string youtube = "") {
            //TODO: connect this to users and a DB of some kind so that we can have multiple users and they can customize the look and which elements show.
            var model = new Social { Twitter = twitter, YouTube = youtube, Facebook = "" };
            var content = await _viewRenderService.RenderToStringAsync("Social", model);

            return Content(content, "text/html");
        }
        
    }
}
