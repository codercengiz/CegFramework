using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.Entities;

namespace CegFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepositoryBase<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;

        public EfQueryableRepositoryBase(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> Table
        {
            get => this.Entities;
        }

        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }

    }
}
