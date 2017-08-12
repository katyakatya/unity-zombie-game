using System;
using System.Collections.Generic;

namespace TestTask_game
{
    public class RandomPlayer: IPlayer
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int CountOfAttempts { get; set; }
        public List<int> AlreadyTriedNumbers { get; set; }

        public int GetNumberToGuess()
        {
            Random random = new Random();
            int guessNumber = random.Next(40, 140);
            CountOfAttempts++;
            return guessNumber;
        }
    }
}
