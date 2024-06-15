namespace GameZone.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Area> Area { get; set; }
    }
}
