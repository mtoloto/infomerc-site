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
        private readonly UsuarioContext _context;

        public LoginController(UsuarioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Registro(Usuario usuario)
        {

            List<string> erros;
            erros = new List<string>();

            //verificar as informações
            if (string.IsNullOrEmpty(usuario.Nome))
                erros.Add("Nome é obrigatório");
            if (string.IsNullOrEmpty(usuario.Email))
                erros.Add("E-mail é obrigatório");
            if (string.IsNullOrEmpty(usuario.Telefone))
                erros.Add("Telefone é obrigatório");
            if (string.IsNullOrEmpty(usuario.Senha) || usuario.Senha.Length < 6)
                erros.Add("Senha deve ter mais que 6 caractéres");
            if (string.IsNullOrEmpty(usuario.Interesse))
                erros.Add("Selecione um interesse");


            //verificar se email já existe
            var jaExiste = _context.Usuarios.Count(x => x.Email == usuario.Email) > 0;

            if (jaExiste)
                erros.Add("E-mail já cadastrado");


            if (erros.Count > 0)
                return Json(new { erros });

            var bdUsuario = new UsuarioRepositorioEF(_context);



            usuario.DataCadastro = DateTime.Now;

            bdUsuario.Adicionar(usuario);
            bdUsuario.SalvarTodos();

            return Json("");
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario, bool lembrarme = false)
        {

            var _usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);

            if (_usuario != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, _usuario.Nome));
                identity.AddClaim(new Claim(ClaimTypes.Name, _usuario.Nome));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
            }

            return RedirectToAction("Index", "Home");

        }

        //[HttpPost]
        //public async Task OnPostAsync(Usuario usuario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var isValid = (usuario.Email == "asd@asd.com" && usuario.Senha == "123456");
        //        if (!isValid)
        //        {
        //            ModelState.AddModelError("", "username or password is invalid");
        //            return View();
        //        }
        //         return RedirectToPage("Index");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "username or password is blank");
        //        return Page();
        //    }
        //}
    }
}
