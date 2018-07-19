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
    public class DocVersionRepository : Repository<DocVersion, DocVersionFilter>
    {
        public DocVersionRepository(ISession session) :
            base(session)
        {
        }

        public IList<DocVersion> Find(DocVersionFilter filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<DocVersion>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.DocName))
                {
                    crit.Add(Restrictions.Eq("DocName", filter.DocName));
                }
                if (!string.IsNullOrEmpty(filter.Author))
                {
                    crit.Add(Restrictions.Eq("Author", filter.Author));
                }
                if (filter.Date != null)
                {
                    if (filter.Date.From.HasValue)
                    {
                        crit.Add(Restrictions.Ge("WorkStartDate", filter.Date.From.Value));
                    }
                    if (filter.Date.To.HasValue)
                    {
                        crit.Add(Restrictions.Le("WorkStartDate", filter.Date.To.Value));
                    }
                }
            }
            SetupFetchOptions(crit, options);
            return crit.List<DocVersion>();
        }
    }
}