using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantsAPI.Application.Restaurants;
using RestaurantsAPI.Application.Restaurants.DTOs;

namespace RestaurantsAPI.API.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController(RestaurantsService restaurantsService, IValidator<CreateRestaurantDto> validator) : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantsService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await restaurantsService.GetRestaurantByIdAsync(id);

            if(restaurant != null)
            {
                return Ok(restaurant);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost] 
        public async Task<IActionResult> Create([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            var validationResult = await validator.ValidateAsync(createRestaurantDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            int id = await restaurantsService.Create(createRestaurantDto);
            return CreatedAtAction(
                nameof(GetById),
                new { id },
                null
            );
        }
    }
}
