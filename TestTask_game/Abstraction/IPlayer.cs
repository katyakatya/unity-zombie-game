using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_game
{
    public interface IPlayer
    {
        string Name { get; set; }
        string Type { get; set; }
        int CountOfAttempts { get; set; }
        List<int> AlreadyTriedNumbers { get; set; }
        int GetNumberToGuess();
    }
}
