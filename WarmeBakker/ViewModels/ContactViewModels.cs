using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarmeBakker.Models;
using WarmeBakker.Data;
using WarmeBakkerLib;
using System.Collections.ObjectModel;

namespace WarmeBakker.ViewModels
{
    public class ContactViewModels


    {
   
    
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Onderwerp { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage ="Te groot bericht.")]
        public string Message { get; set; }
    }

    
}
