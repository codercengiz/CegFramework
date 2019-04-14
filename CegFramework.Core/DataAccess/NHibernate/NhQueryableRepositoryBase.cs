using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.Entities;
using NHibernate.Linq;

namespace CegFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableRepositoryBase<T> : IQueryableRepository<T> where T : class, IEntity,new()

    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;
        public NhQueryableRepositoryBase(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }


        public IQueryable<T> Table => this.Entities;

        public IQueryable<T> Entities
        {
            get { return _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>()); }
        }
    }
}
