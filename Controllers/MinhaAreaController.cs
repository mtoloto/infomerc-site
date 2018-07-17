using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infomerc_site.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace infomerc_site.Controllers
{
    [Authorize]
    public class MinhaAreaController : Controller
    {
        private readonly UserManager<Usuario> _userManager;

        public MinhaAreaController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.Nome = user.Nome;
            return View();
        }
    }
}
