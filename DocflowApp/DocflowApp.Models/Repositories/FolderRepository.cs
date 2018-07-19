using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocflowApp.Models.Filters;
using NHibernate;
using NHibernate.Criterion;

namespace DocflowApp.Models.Repositories
{
    [Repository]
    public class FolderRepository : Repository<Folder, FolderFilter>
    {
        public FolderRepository(ISession session) :
            base(session)
        {
        }

        public IList<Folder> Find(FolderFilter filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<Folder>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.FolderName))
                {
                    crit.Add(Restrictions.Eq("Name", filter.FolderName));
                }
                if (filter.Root != null)
                {
                    crit.Add(Restrictions.Eq("Root", filter.Root));
                }
                if (filter.User != null)
                {
                    crit.Add(Restrictions.Eq("User", filter.User));
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
            return crit.List<Folder>();
        }
    }
}