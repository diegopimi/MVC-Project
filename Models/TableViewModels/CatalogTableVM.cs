using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models.TableViewModels
{
    public class CatalogTableVM
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public int IdBook_Class { get; set; }

        public int ClassId { get; set; }
        public string Classname { get; set; }

    }

}