using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StreamTools.Controllers
{
    [Produces("application/json")]
    [Route("api/Vehicle")]
    public class VehicleController : Controller
    {
        private readonly StreamTools.IViewRenderService _viewRenderService;
        public VehicleController(StreamTools.IViewRenderService viewRenderService) {
            _viewRenderService = viewRenderService;
        }

        // GET api/values/5
        [HttpGet]
        public async Task<ActionResult> Get() {
            //TODO: connect this to users and a DB of some kind so that we can have multiple users and they can customize the look and which elements show.
            //var model = new Social { Twitter = twitter, YouTube = youtube, Facebook = "" };
            var content = await _viewRenderService.RenderToStringAsync("Vehicle", null);

            return Content(content, "text/html");
        }
    }
}