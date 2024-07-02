using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using RouletteAPI.Data;

namespace RouletteAPI.Models
{
    public class Bet
    {
        [Key]
        public Guid Id { get; set; }
        public int BetTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DatePlaced { get; set; }
        public Guid RoundId { get; set; }
        public double BetAmount { get; set; }
        public double BetPayout { get; set; }
        public int[]? ChosenNumbers { get; set; }
    }
}
