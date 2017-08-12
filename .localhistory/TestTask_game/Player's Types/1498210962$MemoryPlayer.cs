using System;
using System.Collections.Generic;

namespace TestTask_game
{
    public class MemoryPlayer : IPlayer
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int CountOfAttempts { get; set; }
        public List<int> AlreadyTriedNumbers
        {
            get
            {
                return new List<int>();
            }
            set { AlreadyTriedNumbers = value; }
        }

        public int GetNumberToGuess()
        {
            Random random = new Random();
            int guessNumber = random.Next(40, 140);
        Check: if (AlreadyTriedNumbers.Contains(guessNumber))
            {
                guessNumber = random.Next(40, 140);
                goto Check;
            }
            AlreadyTriedNumbers.Add(guessNumber);
            CountOfAttempts++;
            return guessNumber;
        }
    }
}
