using DATA.Repositories;
using DOMAIN;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICES
{
    public partial interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        IPagedList<Supplier> GetPaging(int pageNumber, int pageSize);
    }
    public partial class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }

        public IPagedList<Supplier> GetPaging(int pageNumber, int pageSize)
        {
            return _supplierRepository.GetPaging(pageNumber, pageSize);
        }
    }
}
