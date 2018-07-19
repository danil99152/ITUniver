using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models.Filters
{
    public class FolderFilter : BaseFilter
    {
        [Display(Name = "Название папки")]
        public virtual string FolderName { get; set; }

        [Display(Name = "Автор")]
        public virtual User User { get; set; }

        [Display(Name = "Дата создания папки")]
        public virtual DateRange Date { get; set; }

        [Display(Name = "Корневая папка")]
        public Folder Root { get; set; }
    }
}
