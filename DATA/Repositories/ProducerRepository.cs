using DATA.DataInterface;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Repositories
{
    public interface IProducerRepository : IEntityRepository<Producer>
    {
    }
    public partial class ProducerRepository : EntityRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(ShopOnlineDbContext entitiesContext) : base(entitiesContext)
        {
        }
    }
}
