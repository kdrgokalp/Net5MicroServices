using MediatR;

using Order.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Queries
{
    public class GetOrdersBySellerUsernameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public GetOrdersBySellerUsernameQuery(string userName)
        {
            this.UserName = userName;
        }
        public string UserName { get; set; }
    }
}
