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

        public async Task<MyFavourite> AddMyFavouriteAsync(MyFavourite myFavourite)
        {
            await _dbContext.AddAsync(myFavourite);
            await _dbContext.SaveChangesAsync();
            return myFavourite;
        }
    }
}
