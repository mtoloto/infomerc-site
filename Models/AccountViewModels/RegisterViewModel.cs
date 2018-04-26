using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace infomerc_site.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")] 
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Senha é obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caractéres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Digite novamente")]
        [Compare("Password", ErrorMessage = "Senha e confirmação de senha não são iguais.")]
        public string ConfirmPassword { get; set; }
    }
}
