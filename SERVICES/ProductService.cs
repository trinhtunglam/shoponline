using DATA.DataInterface;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DATA.Repositories;

namespace SERVICES
{
    public partial interface IProductService
    {
        IEnumerable<Product> GetAll();
        void Save();
    }
    public partial class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Save()
        {
            _productRepository.Save();
        }
    }
}
