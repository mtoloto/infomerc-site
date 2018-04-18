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
        public async Task<JsonResult> Registro(Usuario usuario, bool lembrarme = false)
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
            usuario.Premium = false;
            usuario.Ativo = true; 

            bdUsuario.Adicionar(usuario);
            bdUsuario.SalvarTodos();

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Email)); 
            identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });

            return Json(new { logado = true });
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario, bool lembrarme = false)
        {
            var _usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
            if (_usuario != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, _usuario.Email));
                identity.AddClaim(new Claim(ClaimTypes.Name, _usuario.Nome));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
            }
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
