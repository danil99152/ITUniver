using FluentNHibernate.Mapping;

namespace DocflowApp.Models
{
    public class DocumentMap : SubclassMap<Document>
    {
        public DocumentMap()
        {
            Map(d => d.Version).Length(500);
          
           // HasMany(x => x.Versions).Inverse().Cascade.SaveUpdate();
        }
    }
}

