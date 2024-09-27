namespace carpark_info_assignment.Models
{
    public class MyFavouriteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Carpark> Carparks { get; set; } = new List<Carpark>();
    }
}
