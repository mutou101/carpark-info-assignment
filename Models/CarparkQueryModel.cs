namespace carpark_info_assignment.Models
{
    public class CarparkQueryModel
    {
        public string? FreeParking { get; set; }

        public bool? NightParking { get; set; }

        public double? GantryHeight { get; set; }

        public int PageSize { get; set; } = 10;

        public int? Page { get; set; }

    }
}
