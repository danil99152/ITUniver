using DocflowApp.Models.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocflowApp.Filters
{
    public class DocVersionFilter : BaseFilter
    {
        [Display(Name = "Имя документа")]
        public string DocName { get; set; }

        public DateRange Date { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

    }
}