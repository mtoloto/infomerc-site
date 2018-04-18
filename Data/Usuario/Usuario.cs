using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace infomerc_site.Models
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Interesse { get; set; }
        public bool Premium { get; set; }
        public bool Administrador { get; set; }
    }
}