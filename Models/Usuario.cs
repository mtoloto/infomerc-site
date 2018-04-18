using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace infomerc_site.Models
{
    [Table("INFOMERC_USUARIO")]
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email{ get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Interesse { get; set; }
        public bool Ativo { get; set; }
        public bool Premium { get; set; }
    }
}