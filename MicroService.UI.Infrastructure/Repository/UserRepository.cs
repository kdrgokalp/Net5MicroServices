using MicroService.UI.Core.Entities;
using MicroService.UI.Core.Repositories;
using MicroService.UI.Infrastructure.Data;
using MicroService.UI.Infrastructure.Repository.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.UI.Infrastructure.Repository
{
    public class UserRepository :  Repository<AppUser>, IUserRepository
    {
        private readonly WebAppContext _dbContext;

        public UserRepository(WebAppContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
