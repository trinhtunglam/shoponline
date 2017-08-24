using DATA.DataInterface;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Repositories
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
    public partial class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(ShopOnlineDbContext entitiesContext) : base(entitiesContext)
        {
        }
    }
}
