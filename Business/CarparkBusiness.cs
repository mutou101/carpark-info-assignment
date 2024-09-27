using carpark_info_assignment.CarparkDb;
using carpark_info_assignment.Models;

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
                   where (carpark.FreeParking.Contains(carparkQuery.FreeParking) || carpark.NightParking == carparkQuery.NightParking || carpark.GantryHeight >= carparkQuery.GantryHeight)
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
            foreach (var item in list)
            {
                await AddCarparkAsync(item);
            }
            return [.. list];
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
