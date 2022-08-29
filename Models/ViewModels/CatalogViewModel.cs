using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //library for annotations

namespace MyProject.Models.ViewModels
{
    public class CatalogViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The email needs to have at least {1} characters", MinimumLength = 1)]
        [Display(Name = "Author: ")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Title: ")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Classification: ")]
        public int IdBook_Class{ get; set; }

    }
    public class EditCatalogViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Author needs to have at least {1} characters", MinimumLength = 1)]
        [Display(Name = "Author: ")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Title: ")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Classification: ")]
        public int IdBook_Class { get; set; }

    }

}