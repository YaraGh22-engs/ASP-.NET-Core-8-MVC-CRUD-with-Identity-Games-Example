namespace GameZone.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty;
        //public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
        public ICollection<GameDevice> Games { get; set; } = new List<GameDevice>();

    }
}
