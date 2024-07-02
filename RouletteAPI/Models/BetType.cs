using System.ComponentModel.DataAnnotations;

namespace RouletteAPI.Models
{
    public class BetType
    {
        [Key]
        public int Id { get; set; }
        public int[]? NumbersInBet { get; set; }
        public int BetRate { get; set; }
    }
}
