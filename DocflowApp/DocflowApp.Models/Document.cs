﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocflowApp.Models
{
    public class Document : Folder
    {
        public virtual string Version { get; set; }
     
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
