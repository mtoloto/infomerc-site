﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infomerc_site.Models;

namespace infomerc_site.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Post()
        {
            return View();
        }
    }
}
