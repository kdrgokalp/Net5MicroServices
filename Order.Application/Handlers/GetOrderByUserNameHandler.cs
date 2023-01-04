using AutoMapper;

using MediatR;

using Order.Application.Queries;
using Order.Application.Responses;
using Order.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Handlers
{
    public class GetOrderByUserNameHandler : IRequestHandler<GetOrdersBySellerUsernameQuery, IEnumerable<OrderResponse>>
    {
          private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByUserNameHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersBySellerUsernameQuery request, CancellationToken cancellationToken)
        {
            //var orderList = await _orderRepository.GetOrdersBySellerName(request.UserName);
            var orderList = new List<Domain.Entities.Order>();
            var response = _mapper.Map<IEnumerable<OrderResponse>>(orderList);
            return response;
        }
    }
}
