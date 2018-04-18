using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infomerc_site.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace infomerc_site.Controllers
{ 
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
    }
}
