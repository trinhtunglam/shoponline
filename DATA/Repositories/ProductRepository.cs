using DATA.DataInterface;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATA.Repositories
{
    public interface IProductRepository : IEntityRepository<Product>
    {
    }
    public partial class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopOnlineDbContext entitiesContext) : base(entitiesContext)
        {
        }
        //private readonly IEntityRepository<Product> _productRepository;

        //public ProductRepository(IEntityRepository<Product> productRepository)
        //{
        //    this._productRepository = productRepository;
        //}

        //public IList<Product> GetAll()
        //{
        //    var query = from c in _productRepository.Table select c;
        //    //query = query.OrderBy(t => t.Name);
        //    return query.ToList();
        //}
    }
}
