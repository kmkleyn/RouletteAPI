using RouletteAPI.Enums;
using RouletteAPI.Models;

namespace RouletteAPI.Factories
{
    public static class BetTypeFactory
    {
        public static BetType GetBetType(BetTypeEnum betType)
        {
            switch (betType)
            {
                case BetTypeEnum.First12:
                    return new BetType()
                    {
                        BetRate = 2,
                        NumbersInBet = new int[] { 1,2,3,4,5,6,7,8,9,10,11,12 }
                    };
                case BetTypeEnum.Even:
                    return new BetType()
                    {
                        BetRate = 1,
                        NumbersInBet = new int[] { 2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36 }
                    };
                // TODO: Implement each bet type
                default:
                    break;
            };
            return new BetType();
                

        }
    }
}
