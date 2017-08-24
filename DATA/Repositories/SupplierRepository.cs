using DATA.DataInterface;
using DOMAIN;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATA.Repositories
{
    public interface ISupplierRepository : IEntityRepository<Supplier>
    {
        IPagedList<Supplier> GetPaging(int pageNumber, int pageSize);
    }
    public partial class SupplierRepository : EntityRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ShopOnlineDbContext entitiesContext) : base(entitiesContext)
        {
        }

        public IPagedList<Supplier> GetPaging(int pageNumber, int pageSize)
        {
            IQueryable<Supplier> model = _entitiesContext.Set<Supplier>();
            var tests =model .Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new StaticPagedList<Supplier>(tests, pageNumber, pageSize, model.Count());
        }
    }
}
