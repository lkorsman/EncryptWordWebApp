using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EWWebApp.Models
{
    public class EncryptWordModel
    {
        [Display(Name = "Word", Description = "Word to encrypt")]
        [Required(ErrorMessage = "Word is required")]
        public string Word { get; set; }
    }
}
