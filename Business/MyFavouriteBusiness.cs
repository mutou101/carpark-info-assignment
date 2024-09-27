using carpark_info_assignment.CarparkDb;
using carpark_info_assignment.Models;

namespace carpark_info_assignment.Business
{
    public class MyFavouriteBusiness
    {
        private readonly SQLiteDbContext _dbContext;
        public MyFavouriteBusiness(SQLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<MyFavouriteModel> GetAll(string name) {

            return from myFavourite in _dbContext.MyFavourites
                   where myFavourite.Name.ToLower() == name.ToLower()
                   select new MyFavouriteModel
                   {
                        Id = myFavourite.Id,
                        Name = myFavourite.Name,
                        Carparks = myFavourite.Carparks
                   };
        }

        public async Task<MyFavouriteModel> Created(MyFavouriteModel myFavourite)
        {
            var entity = new MyFavourite
            {
                Name = myFavourite.Name
            };
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return myFavourite;
        }
    }
}
