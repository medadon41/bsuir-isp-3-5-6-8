using System;

namespace Lab3
{

    class Program
    {
        static bool сheckInt(string _int)
        {
            if (int.TryParse(_int, out int test)) { return true; }
            else return false;
        }

        static void Main(string[] args)
        {
            Players players = new Players();

            players[0].board.fillBoard();
            players[1].board.fillBoard();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Enemy Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            players[1].board.show();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Your Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            players[0].board.show();

            Console.Write("\nChoose a minion which will attack (it's position on your board): ");

            string _minion = Console.ReadLine();

            while(!int.TryParse(_minion, out int test) || int.Parse(_minion) > players[0].board.length())
            {
                Console.Write("Choose a minion which will attack (it's position on your board): ");
                _minion = Console.ReadLine();
            }

            int minion = int.Parse(_minion) - 1;

            Console.Write("\nChoose a minion to attack (it's position on enemy board): ");

            string _target = Console.ReadLine();

            while (!int.TryParse(_target, out int test) || int.Parse(_target) > players[1].board.length())
            {
                Console.Write("Choose a minion to attack (it's position on enemy board): ");
                _target = Console.ReadLine();
            }

            int target = int.Parse(_target) - 1;

            players[0].board[minion].Attack(players[1].board[target]);
            players[0].board.Refill();
            players[1].board.Refill();

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Enemy Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            players[1].board.show();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Your Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            players[0].board.show();

        }

    }
}

