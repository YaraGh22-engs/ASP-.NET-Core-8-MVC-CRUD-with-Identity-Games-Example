using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class GameDevice
    {

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; } = default!;
        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public Device Device { get; set; } = default!;
    }
}
