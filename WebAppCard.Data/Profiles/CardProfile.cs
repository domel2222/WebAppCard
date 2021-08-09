using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Data.DTO;
using WebAppCard.Data.Models;

namespace WebAppCard.Data.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            ReadDto();
        }



        private void ReadDto()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(o => o.OrderId, oDto => oDto.MapFrom(x => x.Id))
                .ReverseMap();


            // adjut this method
            CreateMap<OrderItem, OrderItemDTO>()
                .ReverseMap();
        }
    }
}
