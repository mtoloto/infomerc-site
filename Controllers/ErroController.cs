using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infomerc_site.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace infomerc_site.Controllers
{
    public class ErroController : Controller
    {
        public IActionResult Index()
        {
            // Get the details of the exception that occurred
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                // Get which route the exception occurred at
                string routeWhereExceptionOccurred = exceptionFeature.Path;

                // Get the exception that occurred
                Exception exceptionThatOccurred = exceptionFeature.Error;
                ViewBag.Error = exceptionThatOccurred.Message;
                // TODO: Do something with the exception
                // Log it with Serilog?
                // Send an e-mail, text, fax, or carrier pidgeon?  Maybe all of the above?
                // Whatever you do, be careful to catch any exceptions, otherwise you'll end up with a blank page and throwing a 500
            }

            // handle different codes or just return the default error view
            // ViewBag.Error = code;
            return View();
        }

        public IActionResult Descricao(int code)
        {
            ViewBag.Error = code;
            return View();
        }

        [Route("erro/descricao/404")]
        public IActionResult Erro404(int code)
        { 
            return View();
        }
    }
}
