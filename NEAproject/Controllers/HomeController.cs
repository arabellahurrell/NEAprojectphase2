using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEAproject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NEAproject.Services;
using Microsoft.AspNetCore.Identity;
using NEAproject.Data;

namespace NEAproject.Controllers
{
    public class HomeController : Controller
    {
        private NEAdbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private IHostingEnvironment _enviroment;
        private readonly IViewRenderService _renderService;


        public HomeController(ILogger<HomeController> logger, IHostingEnvironment enviroment, IViewRenderService renderService, UserManager<IdentityUser> userManager, NEAdbContext context)
        {
            _logger = logger;
            _enviroment = enviroment;
            _renderService = renderService;
            _userManager = userManager;
            _context = context;


        }
        public ActionResult Index(homemodel homemodel, bool? loginsuccess = false)
            //ActionResult adds another task to render the page on the browser in this instance. bridge between CSS/HTML page and browser
        {
            //to the code
            if (homemodel.selectcomplexity == "getLineardatapoints")
            {
                ViewBag.datapointlist = JsonConvert.SerializeObject(Helper.getLineardatapoints(homemodel.valueofn));
            }
            else if (homemodel.selectcomplexity == "getNtothe2points")
            {
                ViewBag.datapointlist = JsonConvert.SerializeObject(Helper.getNtothe2points(homemodel.valueofn));
            }
            else if (homemodel.selectcomplexity == "get2totheNpoints")
            {
                ViewBag.datapointlist = JsonConvert.SerializeObject(Helper.get2totheNpoints(homemodel.valueofn));
            }
            else if (homemodel.selectcomplexity == "getlogn")
            {
                ViewBag.datapointlist = JsonConvert.SerializeObject(Helper.getlogn(homemodel.valueofn));
            }
            else if (homemodel.selectcomplexity == "getnlogn")
            {
                ViewBag.datapointlist = JsonConvert.SerializeObject(Helper.getnlogn(homemodel.valueofn));
            }
            else
            {
                List<datapoint> datapointlist = new List<datapoint>();
                datapointlist.Add(new datapoint("0", 0));
                datapointlist.Add(new datapoint("1", 1));
                datapointlist.Add(new datapoint("2", 2));
                datapointlist.Add(new datapoint("3", 3));
                datapointlist.Add(new datapoint("4", 4));
                datapointlist.Add(new datapoint("5", 5));
                datapointlist.Add(new datapoint("6", 6));
                datapointlist.Add(new datapoint("7", 7));
                datapointlist.Add(new datapoint("8", 8));
                datapointlist.Add(new datapoint("9", 9));
                datapointlist.Add(new datapoint("10", 10));
                datapointlist.Add(new datapoint("11", 11));
                datapointlist.Add(new datapoint("12", 12));
                datapointlist.Add(new datapoint("13", 13));
                datapointlist.Add(new datapoint("14", 14));
                datapointlist.Add(new datapoint("15", 15));



                ViewBag.datapointlist = JsonConvert.SerializeObject(datapointlist);
            }

            if (loginsuccess == true)
            {
                ViewData["Loginsuccessful"] = true;
            }
            
            return View(homemodel);
        }

        public async Task<ActionResult> RenderGraph(string selectcomplexity, int valueofn)
        {
            homemodel model = new homemodel();
            model.selectcomplexity = selectcomplexity;
            model.valueofn = valueofn;

            var result = await _renderService.RenderToStringAsync("Home/Index", model);
            fileoperation.converttopdf2(DateTime.Now.ToString("ddMMMyyyyhhmmss") + ".pdf", _enviroment.WebRootPath, User.Identity.Name, result);
            //date before time normally you can put time first tho
            //day can be integer as well as 3 character from day name such as sunday = sun dd return day as integer in 2 digits but ddd returns 3 characters from name of day as a string dddd full name 
            //also could only use 2 for year tho not as accurate because it can be wrong but current year it would be fine
            //when we apply only 2 time MM it will return month as integer with 2 digits when we apply MMM 3 times month value will be returned in month name but 3 charchter for exaple march is mar
            //if storing in database then more memory will be occupied which is why we use MMM instead of MMMM and dd instead of dddd
            //however for displaying purposes it is nice to have full names 
            return RedirectToAction("Index","Home");
            return Content(result);
        }
        [Authorize]
        //attribute specifies that this action result is specifically just for post when this form is being submitted
        public ActionResult Comparison(homemodel homemodel)
        {
            //to the code
            ViewBag.Message = "Your comparison page.";
            if (homemodel != null)
            {

                ViewBag.datapointlist = JsonConvert.SerializeObject(Helper.getLineardatapoints(homemodel.valueofn));

                ViewBag.datapointlist1 = JsonConvert.SerializeObject(Helper.getNtothe2points(homemodel.valueofn));

                ViewBag.datapointlist2 = JsonConvert.SerializeObject(Helper.get2totheNpoints(homemodel.valueofn));

                ViewBag.datapointlist3 = JsonConvert.SerializeObject(Helper.getlogn(homemodel.valueofn));

                ViewBag.datapointlist4 = JsonConvert.SerializeObject(Helper.getnlogn(homemodel.valueofn));
            }

           
            return View(homemodel);
        }
        
        
        
        
        public async Task<ActionResult> RenderComparison(int valueofn)
        {
            homemodel model = new homemodel();
            //model.selectcomplexity = "getLineardatapoints";
            model.valueofn = valueofn;

            var result = await _renderService.RenderToStringAsync($"/Views/Home/Comparison.cshtml", model);
            fileoperation.converttopdf2(DateTime.Now.ToString("ddMMMyyyyhhmmss") + ".pdf", _enviroment.WebRootPath, User.Identity.Name, result);
            //date before time normally you can put time first tho
            //day can be integer as well as 3 character from day name such as sunday = sun dd return day as integer in 2 digits but ddd returns 3 characters from name of day as a string dddd full name 
            //also could only use 2 for year tho not as accurate because it can be wrong but current year it would be fine
            //when we apply only 2 time MM it will return month as integer with 2 digits when we apply MMM 3 times month value will be returned in month name but 3 charchter for exaple march is mar
            //if storing in database then more memory will be occupied which is why we use MMM instead of MMMM and dd instead of dddd
            //however for displaying purposes it is nice to have full names 
            return RedirectToAction("Comparison", "Home", model);
            return Content(result);
        }


        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
