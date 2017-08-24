using DATA.DataInterface;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Repositories
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
    }
    public partial class CustomerRepository : EntityRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopOnlineDbContext entitiesContext) : base(entitiesContext)
        {
        }
    }
}
