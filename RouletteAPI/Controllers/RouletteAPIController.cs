using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RouletteAPI.Data;
using RouletteAPI.Enums;
using RouletteAPI.Factories;
using RouletteAPI.Models;

namespace RouletteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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
            try
            {
                var newRound = new Round()
                {
                    RoundId = Guid.NewGuid(),
                    WinningNumber = new Random().Next(0, 36),
                    RoundCreated = DateTime.Now,
                };
                _context.Add(newRound);
                _context.SaveChanges();
                return JsonConvert.SerializeObject(newRound);
            }
            catch (Exception ex) 
            {
                return $"Spin unsuccessful. Error: {ex.Message} Inner Exception: {ex.InnerException}";
            }
        }

        [HttpPost(Name = "PlaceBet")]
        public async Task<string> PlaceBet(int betType, double betAmount, Guid roundId, Guid userId, int[]? chosenNumbers = null)
        {
            try
            {
                var bet = new Bet()
                {
                    Id = Guid.NewGuid(),
                    RoundId = roundId,
                    UserId = userId,
                    ChosenNumbers = chosenNumbers,
                    DatePlaced = DateTime.Now,
                    BetAmount = betAmount,
                    BetTypeId = betType,
                    BetPayout = 0

                };
                _context.Bet.Add(bet);
                _context.SaveChanges();
                return "Successfully placed bet";
            }
            catch (Exception ex)
            {
                return $"Placing bet unsuccessful. Error: {ex.Message} Inner Exception: {ex.InnerException}";
            }
        }

        [HttpPost(Name = "GetPayout")]
        public async Task<string> GetPayout(Guid roundId, Guid userId)
        {
            try
            {
                var betsForRound = _context.Bet.Where(x => x.RoundId == roundId && x.UserId == userId);
                var resultsForRound = new List<Bet>();
                var round = _context.Round.FirstOrDefault(x => x.RoundId == roundId);
                foreach (var bet in betsForRound)
                {
                    if (bet.ChosenNumbers != null && round != null && bet.ChosenNumbers.Contains(round.WinningNumber))
                    {
                        var betPayout = BetTypeFactory.GetBetType((BetTypeEnum)bet.BetTypeId);
                        bet.BetPayout = bet.BetAmount * (betPayout != null ? betPayout.BetRate : 1);
                        _context.Update(bet);
                    }
                    else
                    {
                        bet.BetPayout = 0;
                    }
                    resultsForRound.Add(bet);
                }
                _context.SaveChanges();

                return JsonConvert.SerializeObject(resultsForRound);
            }
            
            catch (Exception ex)
            {
                return $"Getting payout unsuccessful. Error: {ex.Message} Inner Exception: {ex.InnerException}";
            }
        }

        [HttpPost(Name = "ShowPreviousSpins")]
        public async Task<string> ShowPreviousSpins()
        {
            try
            {
                var spins = _context.Round.OrderByDescending(x => x.RoundCreated);
                return JsonConvert.SerializeObject(spins);
            }
            
            catch (Exception ex)
            {
                return $"Retrieving previous spins unsuccessful. Error: {ex.Message} Inner Exception: {ex.InnerException}";
            }
        }
    }
}
