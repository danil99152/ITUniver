using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models
{
    public class FolderMap : ClassMap<Folder>
    {
        public FolderMap()
        {
            Id(d => d.Id).GeneratedBy.Identity();
            Map(d => d.FolderName).Length(200);
            Map(d => d.Date);
            References(f => f.Root).Cascade.SaveUpdate();
            References(x => x.User).Cascade.SaveUpdate();


        }
    }
}