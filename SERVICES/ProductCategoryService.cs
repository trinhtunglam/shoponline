using DATA.Repositories;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICES
{
    public interface IProductCategoryService
    {
        void Create(ProductCategory productCategory);

        void Edit(ProductCategory productCategory);

        void Delete(ProductCategory productCategory);

        void Delete(int id);

        IEnumerable<ProductCategory> GetAll();

        ProductCategory GetById(int productCategoryId);
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this._productCategoryRepository = productCategoryRepository;
        }
        public void Create(ProductCategory productCategory)
        {
            _productCategoryRepository.Add(productCategory);
            _productCategoryRepository.Save();
        }

        public void Delete(ProductCategory productCategory)
        {
            _productCategoryRepository.Delete(productCategory);
            _productCategoryRepository.Save();
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Delete(id);
            _productCategoryRepository.Save();
        }

        public void Edit(ProductCategory productCategory)
        {
            _productCategoryRepository.Edit(productCategory);
            _productCategoryRepository.Save();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public ProductCategory GetById(int productCategoryId)
        {
            return _productCategoryRepository.GetSingleById(productCategoryId);
        }
    }
}
