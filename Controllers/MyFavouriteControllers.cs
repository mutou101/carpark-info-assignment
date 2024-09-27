using carpark_info_assignment.Business;
using carpark_info_assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carpark_info_assignment.Controllers
{
    [Route("api/myFavourite")]
    public class MyFavouriteControllers : ControllerBase
    {
        private readonly MyFavouriteBusiness _myFavouriteBusiness;

        public MyFavouriteControllers(
            MyFavouriteBusiness myFavouriteBusiness)
        {
            _myFavouriteBusiness = myFavouriteBusiness;
        }

        [HttpGet("getByName")]
        public ActionResult<IList<MyFavouriteModel>> GetAll(string name)
        {
            var result =  _myFavouriteBusiness.GetAll(name);
            if (result == null)
            {
                return NotFound();
            }
            return result.ToList();
        }

        [HttpPost("created")]
        public async Task<ActionResult<MyFavouriteModel>> Created(MyFavouriteModel myFavourite)
        {
            var result = await _myFavouriteBusiness.Created(myFavourite);
            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
