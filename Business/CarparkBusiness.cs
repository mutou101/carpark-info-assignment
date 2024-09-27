using carpark_info_assignment.CarparkDb;
using carpark_info_assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace carpark_info_assignment.Business
{
    public class CarparkBusiness
    {
        private readonly SQLiteDbContext _dbContext;
        private readonly CsvService _csvService;
        public CarparkBusiness(SQLiteDbContext dbContext, CsvService csvService)
        {
            _dbContext = dbContext;
            _csvService = csvService;
        }

        public IQueryable<Carpark> GetCarparks() { 
            return from carpark in _dbContext.Carparks select carpark;
        }

        public IQueryable<Carpark> GetCarparksByQuery(CarparkQueryModel carparkQuery)
        {
            if(carparkQuery.FreeParking == null && carparkQuery.NightParking == null && carparkQuery.GantryHeight == null)
            {
                return GetCarparks();
            }
            return from carpark in _dbContext.Carparks 
                   where (carpark.FreeParking.ToLower().Contains(carparkQuery.FreeParking.ToLower()) || 
                   carpark.NightParking == carparkQuery.NightParking || 
                   carpark.GantryHeight >= carparkQuery.GantryHeight)
                   select carpark;
        }

        public async Task<Carpark> AddCarparkAsync(Carpark carpark)
        {
            await _dbContext.AddAsync(carpark);
            await _dbContext.SaveChangesAsync();
            return carpark;
        }

        public async Task<IEnumerable<Carpark>> AddBatchesByUploadAsync(Stream stream)
        {
            var list = _csvService.ReadCsvFile(stream);
            await _dbContext.AddRangeAsync(list);
            await _dbContext.SaveChangesAsync();
            return [.. list];
        }

        public async Task<Carpark> AddMyFavouriteAsync(int carparkId, int myFavouriteId)
        {
            var result = await (from carpark in _dbContext.Carparks where carpark.Id == carparkId select carpark).FirstOrDefaultAsync();
            if (result == null)
            {
                return new Carpark();
            }
            result.MyFavouriteId = myFavouriteId;
            _dbContext.Update(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        private static Carpark ItemCarpark(Carpark carpark) =>
            new Carpark
            {
                Id = carpark.Id,
                Address = carpark.Address,
                XCoord = carpark.XCoord,
                YCoord = carpark.YCoord,
                CarparkType = carpark.CarparkType,
                TypeOfParkingSystem = carpark.TypeOfParkingSystem,
                ShortTermParking = carpark.ShortTermParking,
                FreeParking = carpark.FreeParking,
                NightParking = carpark.NightParking,
                CarparkDecks = carpark.CarparkDecks,
                GantryHeight = carpark.GantryHeight,
                CarparkBasement = carpark.CarparkBasement,
            };
    }
}
