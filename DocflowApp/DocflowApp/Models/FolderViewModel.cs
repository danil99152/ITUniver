using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocflowApp.Models
{
    public class FolderViewModel : EntityViewModel<Folder>
    {

        public string FolderName { get; set; }

        public DateTime CreationDate { get; set; }

        public long? ParentFolder { get; set; }


    }
}