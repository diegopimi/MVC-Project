using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.ViewModels
{
    public class DocumentsViewModel
    {
        [Required] //annotations
        [DisplayName("My document 1")]
        public HttpPostedFileBase Document1 { get; set; }
        [Required]
        [DisplayName("My document 2")]
        public HttpPostedFileBase Document2 { get; set; }
        [Required]
        [DisplayName("My bond")]
        public string Bond { get; set; }

    }
}