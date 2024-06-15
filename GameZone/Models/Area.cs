using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
