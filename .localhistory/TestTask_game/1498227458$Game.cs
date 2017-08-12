using System;
using System.Collections.Generic;

namespace TestTask_game
{
    public class Game
    {
        public static readonly List<int> AllNumberAttempts = new List<int>();
        public const int AttemptsLimit = 100;
        public enum Type
        {
            Random,
            Memory,
            Thorough,
            Cheater,
            ThoroughCheater
        }

        public static int SetWeightForBasket()
        {
            Random randomWeight = new Random();
            int weightOfBasket = randomWeight.Next(40, 140);
            return weightOfBasket;
        }
    }
}
