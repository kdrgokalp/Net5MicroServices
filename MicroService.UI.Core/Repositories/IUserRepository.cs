using MicroService.UI.Core.Entities;
using MicroService.UI.Core.Repositories.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.UI.Core.Repositories
{
    public interface IUserRepository : IRepository<AppUser>
    {
    }
}
