using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infomerc_site.Models;
using infomerc_site.Models.RepositorioEF;
using infomerc_site.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace infomerc_site.Controllers
{
    public class LoginController : Controller
    {
        private readonly InfomercContext _context;

        public LoginController(InfomercContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
