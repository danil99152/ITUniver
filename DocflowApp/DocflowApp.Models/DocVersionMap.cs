using FluentNHibernate.Mapping;
using NHibernate;

namespace DocflowApp.Models
{
    public class DocVersionMap: ClassMap<DocVersion> 
    {
        public DocVersionMap()
        {
            Id(v => v.Id).GeneratedBy.Identity();
            Map(v => v.DocName);
            Map(v => v.Date);
            Map(v => v.Author);
            Map(v => v.Content);

            References(x => x.Document).Cascade.SaveUpdate();

        }
    }
}
