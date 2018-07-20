using DocflowApp.Models.Listeners;
using DocflowApp.Models.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models
{
    public class Folder
    {
        public virtual long Id { get; set; }

        [Display(Name = "Имя папки")]
        public virtual string FolderName { get; set; }

        [Display(Name = "Дата создания папки")]
        [CreationDate]
        public virtual DateTime? Date { get; set; }

        [Display(Name = "Автор")]
        [CreationAuthor]
        public virtual User User { get; set; }

        [Display(Name = "Корневая Папка")]
        public virtual Folder Root { get; set; }

      

    }
}