using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace carpark_info_assignment.Models
{
    public class Carpark
    {
        [Required]
        public int Id { get; set; }
        public int? MyFavouriteId { get; set; }
        public MyFavourite? MyFavourite { get; set; }

        [Name(Constants.CarparkCsvHeaders.CarparkNo)]
        public string CarparkNo { get; set; }

        [Name(Constants.CarparkCsvHeaders.Address)]
        public string Address { get; set; }

        [Name(Constants.CarparkCsvHeaders.XCoord)]
        public double XCoord { get; set; }

        [Name(Constants.CarparkCsvHeaders.YCoord)]
        public double YCoord { get; set; }

        [Name(Constants.CarparkCsvHeaders.CarparkType)]
        public string CarparkType { get; set; }

        [Name(Constants.CarparkCsvHeaders.TypeOfParkingSystem)]
        public string TypeOfParkingSystem { get; set; }

        [Name(Constants.CarparkCsvHeaders.ShortTermParking)]
        public string ShortTermParking { get; set; }

        [Name(Constants.CarparkCsvHeaders.FreeParking)]
        public string FreeParking { get; set; }

        [Name(Constants.CarparkCsvHeaders.NightParking)]
        public Boolean NightParking { get; set; }

        [Name(Constants.CarparkCsvHeaders.CarparkDecks)]
        public int CarparkDecks { get; set; }

        [Name(Constants.CarparkCsvHeaders.GantryHeight)]
        public double GantryHeight { get; set; }

        [Name(Constants.CarparkCsvHeaders.CarparkBasement)]
        public Boolean CarparkBasement { get; set; }
    }
}
