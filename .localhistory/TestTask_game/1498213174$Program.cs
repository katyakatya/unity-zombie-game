using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask_game
{
    public class Program
    {
        static readonly object _locker = new object();
        private static int _overallAmountOfAttempts = 0;

        static void Main(string[] args)
        {

            bool isGameOver = false;

            int weightOfBasket = Game.SetWeightForBasket();
            Console.WriteLine("Real weight : " + weightOfBasket);

            Console.WriteLine("Count of players in this game?");
            var countOfPlayers = Convert.ToInt32(Console.ReadLine());

            var players = new List<IPlayer>();
            for (int i = 0; i < countOfPlayers; i++)
            {
                IPlayer player = null;
                Console.WriteLine("Player's name:");
                string playerName = Console.ReadLine();
                Console.WriteLine("Player's type:");
                string playerType = Console.ReadLine();
                bool isExist = playerType != null && Enum.IsDefined(typeof(Game.Type), value: playerType);
                if (isExist)
                {
                    Type type = Type.GetType("TestTask_game." + playerType + "Player");
                    if (type != null)
                    {
                        player = (IPlayer)Activator.CreateInstance(type);
                    }
                    if (player != null)
                    {
                        player.Name = playerName;
                        player.Type = playerType;
                        players.Add(player);
                    }
                }
            }

            Parallel.ForEach(players, new ParallelOptions(),
                (player) =>
                {
                    Thread thread = new Thread(() => TryToGuess(player, weightOfBasket, players));
                    thread.Start();
                });
            Console.ReadLine();
        }

        private static void TryToGuess(IPlayer player, int weightOfBasket, List<IPlayer> players )
        {
            bool isWinner = false;
            while (!isWinner)
            {
                lock (_locker)
                {
                    if (_overallAmountOfAttempts == Game.AttemptsLimit)
                    {
                        isWinner = true;
                        FindClosestToWinPlayer(players, weightOfBasket);
                        Thread.CurrentThread.Join();
                    }
                    _overallAmountOfAttempts++;

                    int numberToGuess = player.GetNumberToGuess();
                    Game.AllNumberAttempts.Add(numberToGuess);

                    Console.WriteLine("Number is " + numberToGuess + "?" + "Attempt was made by " + player.Name);

                    if (numberToGuess == weightOfBasket)
                    {
                        Console.WriteLine(player.Name + " is a winner. Count of attempts = " + player.CountOfAttempts);
                        isWinner = true;
                        Thread.CurrentThread.Join();
                    }
                    else
                    {
                        int delta = weightOfBasket - numberToGuess;
                        Thread.CurrentThread.Join(Math.Abs(delta) * 1000);
                    }
                    Console.WriteLine(_overallAmountOfAttempts);
                }
            }
        }


        public static void FindClosestToWinPlayer(List<IPlayer> playesrList, int weight)
        {
            int closestNumberPosition = Int32.MaxValue;
            string winnerName = String.Empty;
            foreach (var player in playesrList)
            {
                int currentPlayerClosestNumberPosition =
                    player.AlreadyTriedNumbers.FindIndex(
                        item =>
                            item ==
                            player.AlreadyTriedNumbers.Aggregate(
                                (x, y) => Math.Abs(x - weight) < Math.Abs(y - weight) ? x : y));
                if (currentPlayerClosestNumberPosition < closestNumberPosition)
                {
                    closestNumberPosition = currentPlayerClosestNumberPosition;
                    winnerName = player.Name;
                }
            }
            Console.WriteLine("Winner is " + winnerName);
        }
    }
}
