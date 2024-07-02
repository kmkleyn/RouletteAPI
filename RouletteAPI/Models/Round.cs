using System.ComponentModel.DataAnnotations;
namespace RouletteAPI.Models
{
    public class Round
    {
        [Key]
        public Guid RoundId { get; set; }
        public int WinningNumber { get; set; }
        public DateTime RoundCreated { get; set; }
    }
}
