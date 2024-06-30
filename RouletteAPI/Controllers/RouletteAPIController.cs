using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RouletteAPI.Data;
using RouletteAPI.Models;

namespace RouletteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouletteAPIController : ControllerBase
    {
        private readonly RouletteAPIContext _context;

        public RouletteAPIController(RouletteAPIContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet(Name = "Spin")]
        public async Task<string> Spin()
        {
            return JsonConvert.SerializeObject(new Random().Next(0, 36));
        }

        [HttpPost(Name = "PlaceBet")]
        public async Task PlaceBet(Bet bet)
        {
            _context.Add(bet);
            await _context.SaveChangesAsync();
        }

        public async Task GetPayout(Guid roundId)
        {
            var betsForRound = _context.Bet.Where(x => x.RoundId == roundId);
            foreach (var bet in betsForRound) 
            {
                var betPayout = _context.BetType.Where(x => x.Id == bet.BetTypeId).FirstOrDefault();
                bet.BetPayout = bet.BetAmount * (betPayout != null ? betPayout.BetRate : 1);
                _context.Update(bet);
            }
            _context.SaveChanges();
        }
    }
}
