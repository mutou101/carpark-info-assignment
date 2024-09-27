using Microsoft.Extensions.Hosting;

namespace carpark_info_assignment.Models
{
    public class MyFavourite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Carpark> Carparks { get; } = new List<Carpark>();
    }
}
