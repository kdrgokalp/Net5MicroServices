using AutoMapper;

using EventBusRabbitMQ.Events;

using MicroService.Sourcing.Entities;

namespace MicroService.Sourcing.Mapping
{
    public class SourcingMapping : Profile
    {
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();
        }
    }
}
