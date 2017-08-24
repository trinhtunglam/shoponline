using DATA.DataInterface;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Repositories
{
    public interface IProductCategoryRepository : IEntityRepository<ProductCategory>
    {
    }
    public partial class ProductCategoryRepository : EntityRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ShopOnlineDbContext entitiesContext) : base(entitiesContext)
        {
        }
    }
}
