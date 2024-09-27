using carpark_info_assignment.Business;
using carpark_info_assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carpark_info_assignment.Controllers
{
    [Route("api/carpark")]
    [ApiController]
    public class CarparkControllers : ControllerBase
    {
        private readonly CarparkBusiness _carparkBusiness;
        private readonly MyFavouriteBusiness _myFavouriteBusiness;

        public CarparkControllers(
            CarparkBusiness carparkBusiness, 
            MyFavouriteBusiness myFavouriteBusiness)
        {
            _carparkBusiness = carparkBusiness;
            _myFavouriteBusiness = myFavouriteBusiness;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Carpark>> GetAll([FromQuery]int? page)
        {
            const int pageSize = 10;
            var carparks = _carparkBusiness.GetCarparks();
            var paginatedCarparks = carparks.Skip((page ?? 0) * pageSize)
                .Take(pageSize)
                .ToList();

            if (paginatedCarparks == null) {
                return NotFound();
            }
            return paginatedCarparks;
        }

        [HttpGet("getByQuery")]
        public ActionResult<IEnumerable<Carpark>> GetAllByQuery([FromQuery] CarparkQueryModel carparkQuery)
        {
            carparkQuery.Page ??= carparkQuery.Page = 1;
            var carparks = _carparkBusiness.GetCarparksByQuery(carparkQuery);
            var paginatedCarparks = carparks.Skip((carparkQuery.Page ?? 0) * carparkQuery.PageSize)
                .Take(carparkQuery.PageSize)
                .ToList();

            if (paginatedCarparks == null)
            {
                return NotFound();
            }
            return paginatedCarparks;
        }

        [HttpPost("addCarpark")]
        public async Task<ActionResult<Carpark>> AddCarparkAsync(Carpark carpark)
        {
            var result = await _carparkBusiness.AddCarparkAsync(carpark);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPost("addMyFavourite")]
        public async Task<ActionResult<MyFavourite>> AddMyFavouriteAsync(MyFavourite myFavourite)
        {
            var result = await _myFavouriteBusiness.AddMyFavouriteAsync(myFavourite);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPost("addBatchesByUpload")]
        public async Task<ActionResult> AddBatchesByUploadAsync(IFormFile file)
        {
            var result = await _carparkBusiness.AddBatchesByUploadAsync(file.OpenReadStream());
            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}