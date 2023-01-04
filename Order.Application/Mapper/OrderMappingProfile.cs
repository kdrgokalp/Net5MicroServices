using AutoMapper;

using Order.Application.Commands.OrderCreate;
using Order.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Domain.Entities.Order, OrderCreateCommand>().ReverseMap();
            CreateMap<Domain.Entities.Order, OrderResponse>().ReverseMap();
        }
    }
}
