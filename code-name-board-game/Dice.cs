using System;

namespace code_name_board_game
{
    public static class Dice
    {
        public static int lastRoll { get; set; }

        public static int RollDice(int sides)
        {
            Random randomisedNumber = new Random();
            int rollResult = randomisedNumber.Next(1, sides);
            Console.WriteLine(rollResult);
            lastRoll = rollResult;
            return rollResult;
            }
    }
}

