using AutoMapper;
using DTO;
using Entities;

namespace server
{
    public class Mapper:  Profile
    {
        public Mapper()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            
        }
    }
}
