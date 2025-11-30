using AutoMapper;
using RestaurantsAPI.Domain.Entities;


namespace RestaurantsAPI.Application.Restaurants.Profiles
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DTOs.DishDto>();
        }
    }
}
