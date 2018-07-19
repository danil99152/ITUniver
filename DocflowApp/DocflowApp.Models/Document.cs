using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocflowApp.Models
{
    public class Document : Folder
    {
        public virtual long DocId { get; set; }

        [Display(Name = "Имя файла")]
        public virtual string DocName { get; set; }

        [Display(Name = "Дата начала работы")]
        public virtual DateTime CreationDate { get; set; }

        public virtual string Version { get; set; }

        public virtual Folder Folder { get; set; }

        private IList<Version> _version;
        public virtual IList<Version> Versions
        {
            get
            {
                return _version ?? (_version = new List<Version>());
            }
            set
            {
                _version = value;
            }
        }
    }
}
