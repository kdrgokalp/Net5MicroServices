using AutoMapper;

using MediatR;

using Order.Application.Commands.OrderCreate;
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
    public class OrderCreateHandler : IRequestHandler<OrderCreateCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderCreateHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }
        public async Task<OrderResponse> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            //Business logic işlemleri burada gerçekleştireceğiz.
            var orderEntity = _mapper.Map<Domain.Entities.Order>(request);
            if (orderEntity == null)
            {
                throw new ApplicationException("Entity could not be mapped!");
            }

            var order = await _orderRepository.AddAsync(orderEntity);


            var orderResponse = _mapper.Map<OrderResponse>(order);
            return orderResponse;
        }
    }
}
