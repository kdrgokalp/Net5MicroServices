using Microsoft.EntityFrameworkCore;

using Order.Domain.Repositories;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Domain.Entities.Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext): base(dbContext)
        {

        }
        public async Task<IEnumerable<Domain.Entities.Order>> GetOrdersBySellerName(string userName)
        {
            var orderList = await _dbContext.Orders.Where(o => o.SellerUserName == userName).ToListAsync();
            return orderList;
        }
    }
}
