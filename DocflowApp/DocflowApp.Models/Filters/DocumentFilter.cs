using DocflowApp.Models.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocflowApp.Filters
{
    public class DocumentFilter : BaseFilter
    {
        [Display(Name = "Имя документа")]
        public string DocName { get; set; }

        [Display(Name = "Автора")]
        public string User { get; set; }

        [Display(Name = "Автора")]
        public DateRange CreationDate { get; set; }

    }
}