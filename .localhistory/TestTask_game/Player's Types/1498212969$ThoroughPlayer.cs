using System;
using System.Collections.Generic;

namespace TestTask_game
{
    public class ThoroughPlayer : IPlayer
    {
        public ThoroughPlayer()
        {
            AlreadyTriedNumbers = new List<int>();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int CountOfAttempts { get; set; }
        public List<int> AlreadyTriedNumbers { get; set; }

        public int LastAttemptNumber { get; set; }
        public int GetNumberToGuess()
        {
            int guessNumber = this.LastAttemptNumber + 1;
            this.LastAttemptNumber = guessNumber;
            CountOfAttempts++;
            return guessNumber;
        }
    }
}
