using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEAproject.Controllers
{
    public class BaseController : Controller
    {
        public string username { get { return User.Identity.Name; } }
    }
}
