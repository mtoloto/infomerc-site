using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace infomerc_site.Models
{
    [Table("INFOMERC_BLOG_POST")]
    public class Blog_Post
    {
        public int ID { get; set; }
        public DateTime DataInclusao { get; set; }
        public string Titulo{ get; set; } 
        public string Corpo { get; set; } 
        public string Tags { get; set; } 
        public bool Ativo { get; set; } 
    }
}