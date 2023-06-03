using AutoMapper;
using core7_angular14_azure.Entities;
using core7_angular14_azure.Models.dto;

namespace core7_angular14_azure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserRegister, User>();
            CreateMap<UserLogin, User>();
            CreateMap<UserUpdate, User>();

            CreateMap<Product, ProductModel>();


        }
    }
    

}