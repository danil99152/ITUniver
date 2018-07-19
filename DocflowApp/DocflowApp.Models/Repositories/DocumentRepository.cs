using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DocflowApp.Models.Filters;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Criterion;
using DocflowApp.Filters;

namespace DocflowApp.Models.Repositories
{
    [Repository]
    public class DocumentRepository : Repository<Document, DocumentFilter>
    {
        public DocumentRepository(ISession session) :
            base(session)
        {
        }

        public IList<Document> Find(DocumentFilter filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<Document>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.DocName))
                {
                    crit.Add(Restrictions.Eq("DocName", filter.DocName));
                }
                if (!string.IsNullOrEmpty(filter.User))
                {
                    crit.Add(Restrictions.Eq("User", filter.User));
                }
                if (filter.CreationDate != null)
                {
                    if (filter.CreationDate.From.HasValue)
                    {
                        crit.Add(Restrictions.Ge("WorkStartDate", filter.CreationDate.From.Value));
                    }
                    if (filter.CreationDate.To.HasValue)
                    {
                        crit.Add(Restrictions.Le("WorkStartDate", filter.CreationDate.To.Value));
                    }
                }
            }
            SetupFetchOptions(crit, options);
            return crit.List<Document>();
        }
    }
}