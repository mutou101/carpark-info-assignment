using Microsoft.VisualBasic;
using CsvHelper.Configuration;

namespace carpark_info_assignment.Models
{
    public sealed class CarparkMap : ClassMap<Carpark>
    {
        public CarparkMap()
        {
            Map(m => m.CarparkNo).Name(Constants.CarparkCsvHeaders.CarparkNo);
            Map(m => m.Address).Name(Constants.CarparkCsvHeaders.Address);
            Map(m => m.XCoord).Name(Constants.CarparkCsvHeaders.XCoord);
            Map(m => m.YCoord).Name(Constants.CarparkCsvHeaders.YCoord);
            Map(m => m.CarparkType).Name(Constants.CarparkCsvHeaders.CarparkType);
            Map(m => m.TypeOfParkingSystem).Name(Constants.CarparkCsvHeaders.TypeOfParkingSystem);
            Map(m => m.ShortTermParking).Name(Constants.CarparkCsvHeaders.ShortTermParking);
            Map(m => m.FreeParking).Name(Constants.CarparkCsvHeaders.FreeParking);
            Map(m => m.NightParking).Name(Constants.CarparkCsvHeaders.NightParking)
            .TypeConverterOption.BooleanValues(true, true, new string[] { "YES" })
            .TypeConverterOption.BooleanValues(false, true, new string[] { "NO" });
            Map(m => m.CarparkDecks).Name(Constants.CarparkCsvHeaders.CarparkDecks);
            Map(m => m.GantryHeight).Name(Constants.CarparkCsvHeaders.GantryHeight);
            Map(m => m.CarparkBasement).Name(Constants.CarparkCsvHeaders.CarparkBasement)
            .TypeConverterOption.BooleanValues(true, true, new string[] { "Y" })
            .TypeConverterOption.BooleanValues(false, true, new string[] { "N" });
        }
    }
}
