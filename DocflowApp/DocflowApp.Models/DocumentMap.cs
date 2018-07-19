using FluentNHibernate.Mapping;

namespace DocflowApp.Models
{
    public class DocumentMap : SubclassMap<Document>
    {
        public DocumentMap()
        {
            Map(d => d.Version).Length(500);


            References(x => x.Folder).Cascade.SaveUpdate();
           // HasMany(x => x.Versions).Inverse().Cascade.SaveUpdate();
        }
    }
}

