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
    [Authorize]
    public class MinhaAreaController : Controller
    {
        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            ViewBag.Nome = identity.Name;
            return View();
        }
    }
}
