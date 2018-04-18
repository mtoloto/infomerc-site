using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace infomerc_site.Models
{
    [Table("INFOMERC_BLOG_CATEGORIA")]
    public class Blog_Categoria
    {
        public int ID { get; set; }
        public DateTime DataInclusao { get; set; }
        public string Titulo{ get; set; }
    }
}