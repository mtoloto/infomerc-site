using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace infomerc_site.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name ="Nome")]
        public string Name { get; set; }

        public bool IsEmailConfirmed { get; set; }
         
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefone ou Celular")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
