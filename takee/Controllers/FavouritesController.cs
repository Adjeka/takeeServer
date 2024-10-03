using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using takee.Contracts.Favourites;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouritesService _favouriteService;
        private readonly IUsersService _usersService;
        private readonly IAnimalsService _animalsService;

        public FavouritesController(
            IFavouritesService favouriteService, 
            IUsersService usersService, 
            IAnimalsService animalsService)
        {
            _favouriteService = favouriteService;
            _usersService = usersService;
            _animalsService = animalsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FavouritesResponse>>> GetFavourites()
        {
            var favourites = await _favouriteService.GetAllFavourites();

            var response = favourites.Select(r => new FavouritesResponse(
                r.Id,
                r.User,
                r.Animal));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FavouritesResponse>> GetFavouriteById(Guid id)
        {
            var favourite = await _favouriteService.GetFavouriteById(id);

            var response = new FavouritesResponse(
                favourite.Id,
                favourite.User,
                favourite.Animal);

            return Ok(response);
        }

        [HttpPost]
        [Route("byUser")]
        public async Task<ActionResult<List<FavouritesResponse>>> GetFavouriteByUserId([FromBody] IdRequest request)
        {
            var favourites = await _favouriteService.GetFavouriteByUserId(request.Id);

            var response = favourites.Select(r => new FavouritesResponse(
                r.Id,
                r.User,
                r.Animal));

            return Ok(response);
        }

        [HttpPost]
        [Route("byUserAndAnimal")]
        public async Task<ActionResult<FavouritesResponse>> GetFavouriteByUserIdAndAnimalId([FromBody] FavouritesRequest request)
        {
            var favourite = await _favouriteService.GetFavouriteByUserIdAndAnimalId(request.UserId, request.AnimalId);

            if (favourite == null) 
            {
                return Ok();
            }
            else
            {
                var response = new FavouritesResponse(
                    favourite.Id,
                    favourite.User,
                    favourite.Animal);

                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateFavourite([FromBody] FavouritesRequest request)
        {
            var existingFavourite = await _favouriteService.GetFavouriteByUserIdAndAnimalId(request.UserId, request.AnimalId);

            if (existingFavourite == null) 
            {
                var user = await _usersService.GetUserById(request.UserId);
                var animal = await _animalsService.GetAnimalById(request.AnimalId);

                var favourite = Favourite.Create(
                    Guid.NewGuid(),
                    user,
                    animal);

                if (favourite.IsFailure)
                    return BadRequest(favourite.Error);

                await _favouriteService.CreateFavourite(favourite.Value);
            }

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateFavourite(Guid id, [FromBody] FavouritesRequest request)
        {
            await _favouriteService.UpdateFavourite(id, request.UserId, request.AnimalId);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteFavourite(Guid id)
        {
            await _favouriteService.DeleteFavourite(id);

            return Ok();
        }

        public class IdRequest
        {
            public Guid Id { get; set; }
        }
    }
}
