using System;
using System.Threading;
using System.Threading.Tasks;

namespace Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new();
            //game.SaveData();
            game.Start(7, 1);
            while (!game.GameEnd)
            {
                game.RacerList();
                game.MoveCar();
                Thread.Sleep(100);
                Console.Clear();
            }
            Console.WriteLine();
        }
    }
}
