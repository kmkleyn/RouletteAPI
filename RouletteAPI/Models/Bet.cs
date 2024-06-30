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
    }


//public static class BetEndpoints
//{
//	public static void MapBetEndpoints (this IEndpointRouteBuilder routes)
//    {
//        var group = routes.MapGroup("/api/Bet").WithTags(nameof(Bet));

//        group.MapGet("/", async (RouletteAPIContext db) =>
//        {
//            return await db.Bet.ToListAsync();
//        })
//        .WithName("GetAllBets")
//        .WithOpenApi();

//        group.MapGet("/{id}", async Task<Results<Ok<Bet>, NotFound>> (Guid id, RouletteAPIContext db) =>
//        {
//            return await db.Bet.AsNoTracking()
//                .FirstOrDefaultAsync(model => model.Id == id)
//                is Bet model
//                    ? TypedResults.Ok(model)
//                    : TypedResults.NotFound();
//        })
//        .WithName("GetBetById")
//        .WithOpenApi();

//        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, Bet bet, RouletteAPIContext db) =>
//        {
//            var affected = await db.Bet
//                .Where(model => model.Id == id)
//                .ExecuteUpdateAsync(setters => setters
//                  .SetProperty(m => m.Id, bet.Id)
//                  .SetProperty(m => m.BetTypeId, bet.BetTypeId)
//                  .SetProperty(m => m.UserId, bet.UserId)
//                  );
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("UpdateBet")
//        .WithOpenApi();

//        group.MapPost("/", async (Bet bet, RouletteAPIContext db) =>
//        {
//            db.Bet.Add(bet);
//            await db.SaveChangesAsync();
//            return TypedResults.Created($"/api/Bet/{bet.Id}",bet);
//        })
//        .WithName("CreateBet")
//        .WithOpenApi();

//        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, RouletteAPIContext db) =>
//        {
//            var affected = await db.Bet
//                .Where(model => model.Id == id)
//                .ExecuteDeleteAsync();
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("DeleteBet")
//        .WithOpenApi();
//    }
//}
}
