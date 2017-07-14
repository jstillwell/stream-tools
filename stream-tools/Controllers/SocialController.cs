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
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{twitter}/{youtube}")]
        public async Task<ActionResult> Get(string twitter = "", string youtube = "") {
            var model = new Social { Twitter = twitter, YouTube = youtube, Facebook = "" };
            var content = await _viewRenderService.RenderToStringAsync("Social", model);

            return Content(content, "text/html");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
