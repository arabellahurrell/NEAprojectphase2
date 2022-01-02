using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NEAproject.Services;

namespace NEAproject.Controllers
{
    [Route("render")]
    public class RenderController : Controller
    {
        private readonly IViewRenderService _renderService;
        public RenderController(IViewRenderService renderService)
        {
            _renderService = renderService;
        }
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var result =  await _renderService.RenderToStringAsync("Home/Index", null);
           
            return Content(result);
        }
    }
}
