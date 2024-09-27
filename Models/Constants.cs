using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carpark_info_assignment.Models
{
    public static class Constants
    {
        public class CarparkCsvHeaders
        {
            public const string CarparkNo = "car_park_no";
            public const string Address = "address";
            public const string XCoord = "x_coord";
            public const string YCoord = "y_coord";
            public const string CarparkType = "car_park_type";
            public const string TypeOfParkingSystem = "type_of_parking_system";
            public const string ShortTermParking = "short_term_parking";
            public const string FreeParking = "free_parking";
            public const string NightParking = "night_parking";
            public const string CarparkDecks = "car_park_decks";
            public const string GantryHeight = "gantry_height";
            public const string CarparkBasement = "car_park_basement";
        }
    }
}