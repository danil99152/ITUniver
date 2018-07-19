using System;
using System.ComponentModel.DataAnnotations;

namespace DocflowApp.Models
{
    public class DocVersion
    {
        public virtual long Id { get; set; }

        [Display(Name = "Имя файла")]
        public virtual string DocName { get; set; }

        [Display(Name = "Дата начала работы")]
        public virtual DateTime Date { get; set; }

        [Display(Name = "Автор")]
        public virtual string Author { get; set; }

        public virtual byte[] Content { get; set; }

        public virtual Document Document { get; set; }


    }
}

